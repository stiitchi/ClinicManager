using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Ward.Commands
{
   public class DeleteWardCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteWardCommandHandler : IRequestHandler<DeleteWardCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteWardCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteWardCommand request, CancellationToken cancellationToken)
        {

            var ward = await _context.Wards.Where(a => a.Id == request.Id).FirstOrDefaultAsync();

            var room = await _context.Rooms.Where(a => a.WardId == ward.Id).FirstOrDefaultAsync();

            if(room.Beds.Count() > 0)
            {
                throw new Exception($"First Remove all Beds from Room {room.RoomNumber} before removing this Ward");
            }

            _context.Wards.Remove(ward);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(ward.Id);
        }
    }
}
