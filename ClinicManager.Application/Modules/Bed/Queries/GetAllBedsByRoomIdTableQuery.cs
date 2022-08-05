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
     public class GetAllBedsByRoomIdTableQuery : IRequest<PaginatedResult<BedDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int RoomId { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; }

        public GetAllBedsByRoomIdTableQuery(int pageNumber, int pageSize, string searchString, int roomId, string orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            RoomId = roomId;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }

    public class GetAllBedsByRoomIdTableQueryHandler : IRequestHandler<GetAllBedsByRoomIdTableQuery, PaginatedResult<BedDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBedsByRoomIdTableQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedResult<BedDTO>> Handle(GetAllBedsByRoomIdTableQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BedEntity, BedDTO>> expression = e => new BedDTO
                {
                    BedId       = e.Id,
                    BedNumber   = e.BedNumber,
                    RoomNumber  = e.RoomNumber,
                    PatientId   = e.PatientId,
                    RoomId      = e.RoomId
                };

                IQueryable<BedEntity> query = _context.Beds;

                if (!string.IsNullOrEmpty(request.SearchString))
                    query = query.Where(o => o.BedNumber.ToString().Contains(request.SearchString) ||
                                             o.RoomNumber.ToString().Contains(request.SearchString) ||
                                             o.PatientId.ToString().Contains(request.SearchString)
                                             );

                if (request.OrderBy?.Any() != true)
                {
                    var result = await query
                   .AsNoTracking()
                   .IgnoreQueryFilters()
                   .Select(expression)
                   .Where(x=> x.RoomId == request.RoomId)
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
                    .Where(x => x.RoomId == request.RoomId)
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
