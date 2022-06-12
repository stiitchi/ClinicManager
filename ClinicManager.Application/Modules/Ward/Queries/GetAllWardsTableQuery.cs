using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.WardAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using ClinicManager.Application.Extensions;

namespace ClinicManager.Application.Modules.Ward.Queries
{
   public class GetAllWardsTableQuery : IRequest<PaginatedResult<WardDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; }

        public GetAllWardsTableQuery(int pageNumber, int pageSize, string searchString, string orderBy)
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

    public class GetAllWardsTableQueryHandler : IRequestHandler<GetAllWardsTableQuery, PaginatedResult<WardDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllWardsTableQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedResult<WardDTO>> Handle(GetAllWardsTableQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<WardEntity, WardDTO>> expression = e => new WardDTO
                {
                    WardId = e.Id,
                    WardNumber = e.WardNumber,
                    RoomNumber = e.RoomNumber,
                    TotalBeds = _context.Beds.Where(x => x.WardId == e.Id).Count()
                };

                
                IQueryable<WardEntity> query = _context.Wards;

                if (!string.IsNullOrEmpty(request.SearchString))
                    query = query.Where(o => o.WardNumber.ToString().Contains(request.SearchString) ||
                                             o.RoomNumber.ToString().Contains(request.SearchString) ||
                                             o.TotalBeds.ToString().Contains(request.SearchString)
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
                return await PaginatedResult<WardDTO>.FailureAsync(new List<string> { ex.Message });
            }
        }
    }
}
