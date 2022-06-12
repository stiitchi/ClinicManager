using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Queries
{
   public class GetBedRestRecordByPatientIdQuery : IRequest<Result<MobilityRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetBedRestRecordByPatientIdQueryHandler : IRequestHandler<GetBedRestRecordByPatientIdQuery, Result<MobilityRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetBedRestRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<MobilityRecordDTO>> Handle(GetBedRestRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bedRestEntry = await _context.BedRestTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.BedRestFrequency != 0,
                    cancellationToken);
                if (bedRestEntry == null)
                    throw new Exception("Unable to return Bed Rest Record");

                var dto = new MobilityRecordDTO
                {
                    BedRestFrequency = bedRestEntry.BedRestFrequency,
                    BedRestSignature = bedRestEntry.BedRestSignature,
                    BedRestTime = bedRestEntry.BedRestTime,
                    PatientId = bedRestEntry.PatientId
                };
                return await Result<MobilityRecordDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<MobilityRecordDTO>.FailAsync(ex.Message);
            }
        }
    }
}
