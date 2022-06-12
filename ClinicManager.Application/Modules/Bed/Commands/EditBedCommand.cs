using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Bed.Commands
{
  public class EditBedCommand : IRequest<Result<int>>
    {
        public int BedId { get; set; }
        public int BedNumber { get; set; }
        public  string WardNumber { get; set; }
        public int WardId { get; set; }
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

                var ward = await _context.Wards.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.WardNumber == Convert.ToInt32(request.WardNumber), cancellationToken);
                if (ward == null)
                    throw new Exception("Ward doesn't exist");

                bed.Set(
                    request.BedNumber,
                    request.WardNumber,
                    ward
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
