using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.BedAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Bed.Commands
{
  public class AddBedCommand : IRequest<Result<int>>
    {
        public int BedId { get; set; }
        public int BedNumber { get; set; }
        public int RoomId { get; set; }
    }

    public class AddBedCommandHandler : IRequestHandler<AddBedCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddBedCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddBedCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var beds = await _context.Beds.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.BedNumber == request.BedNumber &&
                                                                                             c.RoomId == request.RoomId, cancellationToken);
                if (beds != null)
                    throw new Exception("Bed already exists");

                var room = await _context.Rooms.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.RoomId, cancellationToken);
                if (room == null)
                    throw new Exception("Room doesn't exist");

                var bed = new BedEntity(
                    request.BedId,
                    request.BedNumber,
                    room
                    );

                await _context.Beds.AddAsync(bed, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(bed.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
