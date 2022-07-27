using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Bed.Commands
{
   public class DeleteBedCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
    }

    public class DeleteBedCommandHandler : IRequestHandler<DeleteBedCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBedCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteBedCommand request, CancellationToken cancellationToken)
        {
            var room = await _context.Rooms.Where(a => a.Id == request.RoomId).FirstOrDefaultAsync();

            var bed  = await _context.Beds.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.Beds.Remove(bed);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(bed.Id);
        }
    }
}
