using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Room.Commands
{
    public class EditRoomCommand : IRequest<Result<int>>
    {
        public int WardId { get; set; }
        public int WardNumber { get; set; }
        public string RoomNumber { get; set; }
    }

    public class EditRoomCommandHandler : IRequestHandler<EditRoomCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public EditRoomCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(EditRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var room = await _context.Rooms.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.RoomNumber == request.RoomNumber, cancellationToken);
                if (room == null)
                    throw new Exception("Room does not exist");

                var ward = await _context.Wards.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.WardId, cancellationToken);
                if (ward == null)
                    throw new Exception("Ward doesn't exist");

                room.Set(
                    request.RoomNumber,
                    ward
                    );

                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(room.RoomNumber);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
