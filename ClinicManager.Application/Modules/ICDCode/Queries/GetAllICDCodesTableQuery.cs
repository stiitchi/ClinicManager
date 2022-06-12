using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ICDCodeAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using ClinicManager.Application.Extensions;

namespace ClinicManager.Application.Modules.ICDCode.Queries
{
   public class GetAllICDCodesTableQuery : IRequest<PaginatedResult<ICDCodeDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; }

        public GetAllICDCodesTableQuery(int pageNumber, int pageSize, string searchString, string orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }

    public class GetAllICDCodesTableQueryHandler : IRequestHandler<GetAllICDCodesTableQuery, PaginatedResult<ICDCodeDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllICDCodesTableQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedResult<ICDCodeDTO>> Handle(GetAllICDCodesTableQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<ICDCodeEntity, ICDCodeDTO>> expression = e => new ICDCodeDTO
                {
                    ICDCodeId = e.Id,
                    ICDCode = e.IcdCode,
                    DateAdded = e.DateAdded,
                    Description = e.IcdDescription
                };

                IQueryable<ICDCodeEntity> query = _context.ICDCodes;

                if (!string.IsNullOrEmpty(request.SearchString))
                    query = query.Where(o => o.IcdCode.ToString().Contains(request.SearchString) ||
                                             o.IcdDescription.ToString().Contains(request.SearchString)
                                             );

                if (request.OrderBy?.Any() != true)
                {
                    var result = await query
                   .AsNoTracking()
                   .IgnoreQueryFilters()
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return result;
                }
                else
                {
                    var ordering = string.Join(",", request.OrderBy);
                    var result = await query
                    .AsNoTracking()
                    .IgnoreQueryFilters()
                    .OrderBy(ordering)
                    .Select(expression)
                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return await PaginatedResult<ICDCodeDTO>.FailureAsync(new List<string> { ex.Message });
            }
        }
    }
}
