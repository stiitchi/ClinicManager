using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.DayFeesAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using ClinicManager.Application.Extensions;

namespace ClinicManager.Application.Modules.DayFees.Queries
{
 public class GetAllDayFeesTableQuery : IRequest<PaginatedResult<DayFeesDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; }

        public GetAllDayFeesTableQuery(int pageNumber, int pageSize, string searchString, string orderBy)
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

    public class GetAllDayFeesTableQueryHandler : IRequestHandler<GetAllDayFeesTableQuery, PaginatedResult<DayFeesDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllDayFeesTableQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedResult<DayFeesDTO>> Handle(GetAllDayFeesTableQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<DayFeesEntity, DayFeesDTO>> expression = e => new DayFeesDTO
                {
                    DayFeeID        = e.Id,
                    DayFeeCode      = e.DayFeeCode,
                    DateAdded       = e.DateAdded,
                    Description     = e.DayFeeDescription
                };

                IQueryable<DayFeesEntity> query = _context.DayFees;

                if (!string.IsNullOrEmpty(request.SearchString))
                    query = query.Where(o => o.DayFeeCode.ToString().Contains(request.SearchString) ||
                                             o.DayFeeDescription.ToString().Contains(request.SearchString)
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
                return await PaginatedResult<DayFeesDTO>.FailureAsync(new List<string> { ex.Message });
            }
        }
    }
}
