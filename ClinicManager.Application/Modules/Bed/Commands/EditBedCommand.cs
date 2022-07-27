using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Bed.Commands
{
  public class EditBedCommand : IRequest<Result<int>>
    {
        public int BedId { get; set; }
        public int BedNumber { get; set; }
        public string RoomNumber { get; set; }
    }

    public class EditBedCommandHandler : IRequestHandler<EditBedCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public EditBedCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(EditBedCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bed = await _context.Beds.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.BedId, cancellationToken);
                if (bed == null)
                    throw new Exception("Bed does not exist");

                var room = await _context.Rooms.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.RoomNumber == request.RoomNumber, cancellationToken);
                if (room == null)
                    throw new Exception("Room doesn't exist");

                bed.Set(
                    request.BedNumber,
                    room
                    );

                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(bed.BedNumber.ToString());
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
