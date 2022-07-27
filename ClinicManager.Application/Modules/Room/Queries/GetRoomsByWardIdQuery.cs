using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
                var room = await _context.Rooms.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.WardId == request.WardId, cancellationToken);

                if (room == null)
                    throw new Exception("Unable to return Room");

                var dto = new RoomDTO
                {
                    RoomId = room.Id,
                    WardId = room.WardId,
                    RoomNumber = room.RoomNumber,
                    TotalBeds = room.Beds.Count()
                };
                return await Result<List<RoomDTO>>.SuccessAsync();
            }
            catch (Exception ex)
            {
                return await Result<List<RoomDTO>>.FailAsync(ex.Message);
            }
        }
    }
}
