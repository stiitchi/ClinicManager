using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Room.Queries
{
    public class GetRoomsByRoomNumberQuery : IRequest<Result<RoomDTO>>
    {
        public string RoomNumber { get; set; }
    }

    public class GetRoomsByRoomNumberQueryHandler : IRequestHandler<GetRoomsByRoomNumberQuery, Result<RoomDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetRoomsByRoomNumberQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<RoomDTO>> Handle(GetRoomsByRoomNumberQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var room = await _context.Rooms.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.RoomNumber == request.RoomNumber, cancellationToken);

                if (room == null)
                    throw new Exception("Unable to return Room");
                var dto = new RoomDTO
                {
                    RoomId = room.Id,
                    WardId = room.WardId,
                    RoomNumber = room.RoomNumber
                };
                return await Result<RoomDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<RoomDTO>.FailAsync(ex.Message);
            }
        }
    }
}
