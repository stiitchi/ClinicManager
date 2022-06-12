using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Queries
{
   public class GetBedBathRecordByPatientIdQuery : IRequest<Result<HygieneDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetBedBathRecordByPatientIdQueryHandler : IRequestHandler<GetBedBathRecordByPatientIdQuery, Result<HygieneDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetBedBathRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<HygieneDTO>> Handle(GetBedBathRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bedBathEntry = await _context.BedBathTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.BedBathFrequency != 0, cancellationToken);
                if (bedBathEntry == null)
                    throw new Exception("Unable to return Bed Bath Record");

                var dto = new HygieneDTO
                {
                    BedBathTime = bedBathEntry.BedBathTime,
                    BedBathFreq = bedBathEntry.BedBathFrequency,
                    BedBathSignature = bedBathEntry.BedBathSignature,
                    PatientId = bedBathEntry.PatientId
                };
                return await Result<HygieneDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<HygieneDTO>.FailAsync(ex.Message);
            }
        }
    }
}
