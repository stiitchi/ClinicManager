using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
     public class GetBloodGlucoseRecordByPatientIdQuery : IRequest<Result<BloodGlucoseDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetBloodGlucoseRecordByPatientIdQueryHandler : IRequestHandler<GetBloodGlucoseRecordByPatientIdQuery, Result<BloodGlucoseDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetBloodGlucoseRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<BloodGlucoseDTO>> Handle(GetBloodGlucoseRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bloodGlucoseRecord = await _context.BloodGlucoseTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.BloodGlucoseFrequency != 0,
                    cancellationToken);
                if (bloodGlucoseRecord == null)
                    throw new Exception("Unable to return Blood Glucose Record");

                var dto = new BloodGlucoseDTO
                {
                    BloodGlucoseId          = bloodGlucoseRecord.Id,
                    BloodGlucoseFrequency   = bloodGlucoseRecord.BloodGlucoseFrequency,
                    BloodGlucoseSignature   = bloodGlucoseRecord.BloodGlucoseSignature,
                    BloodGlucoseTime        = bloodGlucoseRecord.BloodGlucoseTime,
                    PatientId               = bloodGlucoseRecord.PatientId
                };
                return await Result<BloodGlucoseDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<BloodGlucoseDTO>.FailAsync(ex.Message);
            }
        }
    }
}
