using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Bed.Queries
{
    public class GetBedByIdQuery : IRequest<Result<BedDTO>>
    {
        public int Id { get; set; }
    }

    public class GetBedByIdQueryHandler : IRequestHandler<GetBedByIdQuery, Result<BedDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetBedByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<BedDTO>> Handle(GetBedByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bed = await _context.Beds.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (bed == null)
                    throw new Exception("Unable to return Bed");
                var dto = new BedDTO
                {
                    BedNumber   = bed.BedNumber,
                    RoomNumber  = bed.RoomNumber,
                    PatientId   = bed.PatientId.Value,
                    NurseId     = bed.NurseId.Value,
                    BedId       = bed.Id,
                    RoomId      = bed.RoomId
                };
                return await Result<BedDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<BedDTO>.FailAsync(ex.Message);
            }
        }
    }
}
