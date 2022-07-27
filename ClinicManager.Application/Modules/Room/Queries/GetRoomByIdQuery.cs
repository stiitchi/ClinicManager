using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Room.Queries
{
    public class GetRoomByIdQuery : IRequest<Result<RoomDTO>>
    {
        public int Id { get; set; }
    }

    public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, Result<RoomDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetRoomByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<RoomDTO>> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var room = await _context.Rooms.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (room == null)
                    throw new Exception("Unable to return Room");

                var dto = new RoomDTO
                {
                    RoomId = room.Id,
                    WardId = room.WardId,
                    RoomNumber = room.RoomNumber,
                    TotalBeds = room.Beds.Count()
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
