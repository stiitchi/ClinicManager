using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.RoomAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Room.Queries
{
    public class GetRoomsByWardIdQuery : IRequest<Result<List<RoomDTO>>>
    {
        public int WardId { get; set; }
    }

    public class GetRoomsByWardIdQueryHandler : IRequestHandler<GetRoomsByWardIdQuery, Result<List<RoomDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetRoomsByWardIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<RoomDTO>>> Handle(GetRoomsByWardIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<RoomEntity, RoomDTO>> expression = e => new RoomDTO
                {
                    RoomId = e.Id,
                    RoomNumber = e.RoomNumber,
                    WardId = e.WardId,
                    TotalBeds = e.Beds.Count()
                };

                var rooms = await _context.Rooms
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Where(x => x.WardId == request.WardId)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<RoomDTO>>.SuccessAsync(rooms);
            }
            catch (Exception ex)
            {
                return await Result<List<RoomDTO>>.FailAsync(ex.Message);
            }
        }
    }
}
