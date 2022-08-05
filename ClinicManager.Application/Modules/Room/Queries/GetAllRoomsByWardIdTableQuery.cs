using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Application.Extensions;
using ClinicManager.Domain.Entities.RoomAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Room.Queries
{
    public class GetAllRoomsByWardIdTableQuery : IRequest<PaginatedResult<RoomDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int WardId { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; }

        public GetAllRoomsByWardIdTableQuery(int pageNumber, int pageSize, string searchString, int wardId, string orderBy)
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

    public class GetAllRoomsByWardIdTableQueryHandler : IRequestHandler<GetAllRoomsByWardIdTableQuery, PaginatedResult<RoomDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllRoomsByWardIdTableQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedResult<RoomDTO>> Handle(GetAllRoomsByWardIdTableQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<RoomEntity, RoomDTO>> expression = e => new RoomDTO
                {
                    RoomId      = e.Id,
                    WardId      = e.WardId,
                    RoomNumber  = e.RoomNumber,
                    TotalBeds   = e.Beds.Count()
                };

                IQueryable<RoomEntity> query = _context.Rooms;

                if (!string.IsNullOrEmpty(request.SearchString))
                    query = query.Where(o => o.RoomNumber.ToString().Contains(request.SearchString));

                if (request.OrderBy?.Any() != true)
                {
                    var result = await query
                   .AsNoTracking()
                   .IgnoreQueryFilters()
                   .Where(x => x.WardId == request.WardId)  
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
                    .Where(x => x.WardId == request.WardId)
                    .Select(expression)
                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return await PaginatedResult<RoomDTO>.FailureAsync(new List<string> { ex.Message });
            }
        }
    }
}
