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
        public int WardId { get; set; }
        public int BedNumber { get; set; }
        public string WardNumber { get; set; }
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
                                                                                             c.WardNumber == request.WardNumber,cancellationToken);
                if (beds != null)
                    throw new Exception("Bed already exists");

                var ward = await _context.Wards.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.WardNumber == request.WardNumber, cancellationToken);
                if (ward == null)
                    throw new Exception("Ward doesn't exist");

                var bed = new BedEntity(
                    request.BedNumber,
                    request.WardNumber,
                    ward
                    );

                await _context.Beds.AddAsync(bed, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(ward.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
