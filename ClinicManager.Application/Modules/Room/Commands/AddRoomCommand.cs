using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.RoomAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Room.Commands
{
    public class AddRoomCommand : IRequest<Result<int>>
    {
        public int WardId { get; set; }
        public int WardNumber { get; set; }
        public string RoomNumber { get; set; }
    }

    public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddRoomCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var rooms = await _context.Rooms.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.WardId == request.WardId &&
                                                                                               c.RoomNumber == request.RoomNumber, cancellationToken);
                if (rooms != null)
                    throw new Exception("Room already exists");

                var ward = await _context.Wards.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.WardId, cancellationToken);
                if (ward == null)
                    throw new Exception("Ward doesn't exist");

                var room = new RoomEntity(
                    request.RoomNumber,
                    ward
                    );

                await _context.Rooms.AddAsync(room, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(room.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
