using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.BedAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using ClinicManager.Application.Extensions;

namespace ClinicManager.Application.Modules.Bed.Queries
{
     public class GetAllBedsByWardIdTableQuery : IRequest<PaginatedResult<BedDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int WardId { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; }

        public GetAllBedsByWardIdTableQuery(int pageNumber, int pageSize, string searchString, int wardId, string orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            WardId = wardId;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }

    public class GetAllBedsByWardIdTableQueryHandler : IRequestHandler<GetAllBedsByWardIdTableQuery, PaginatedResult<BedDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBedsByWardIdTableQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedResult<BedDTO>> Handle(GetAllBedsByWardIdTableQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BedEntity, BedDTO>> expression = e => new BedDTO
                {
                    BedId = e.Id,
                    BedNumber = e.BedNumber,
                    WardId = e.WardId,
                    WardNumber = e.WardNumber
                };

                IQueryable<BedEntity> query = _context.Beds;

                if (!string.IsNullOrEmpty(request.SearchString))
                    query = query.Where(o => o.BedNumber.ToString().Contains(request.SearchString) ||
                                             o.WardNumber.ToString().Contains(request.SearchString)
                                             );

                if (request.OrderBy?.Any() != true)
                {
                    var result = await query
                   .AsNoTracking()
                   .IgnoreQueryFilters()
                   .Select(expression)
                   .Where(x=> x.WardId == request.WardId)
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
                    .Where(x => x.WardId == request.WardId)
                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return await PaginatedResult<BedDTO>.FailureAsync(new List<string> { ex.Message });
            }
        }
    }
}
