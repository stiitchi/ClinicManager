using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Room.Commands
{
    public class DeleteRoomCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int WardId { get; set; }
    }

    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRoomCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var wards = await _context.Wards.Where(a => a.Id == request.WardId).FirstOrDefaultAsync();

            var room = await _context.Rooms.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(room.Id);
        }
    }
}
