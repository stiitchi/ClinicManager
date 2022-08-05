using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
     public class GetBloodFrequencyRecordByPatientIdQuery : IRequest<Result<BloodDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetBloodFrequencyRecordByPatientIdQueryHandler : IRequestHandler<GetBloodFrequencyRecordByPatientIdQuery, Result<BloodDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetBloodFrequencyRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<BloodDTO>> Handle(GetBloodFrequencyRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bloodRecord = await _context.BloodTests.AsNoTracking()
                  .IgnoreQueryFilters()
                  .FirstOrDefaultAsync(c => c.PatientId == request.PatientId,
                  cancellationToken);
                if (bloodRecord == null)
                    throw new Exception("Unable to return Blood Record");

                var dto = new BloodDTO
                {
                    BloodId         = bloodRecord.Id,
                    BloodFrequency  = bloodRecord.BloodFrequency,
                    BloodSignature  = bloodRecord.BloodSignature,
                    BloodTime       = bloodRecord.BloodTime,
                    PatientId       = bloodRecord.PatientId
                };
                return await Result<BloodDTO>.SuccessAsync(dto);

            }
            catch (Exception ex)
            {
                return await Result<BloodDTO>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
