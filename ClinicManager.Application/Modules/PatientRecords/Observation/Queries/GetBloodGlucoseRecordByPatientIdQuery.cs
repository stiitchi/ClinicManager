using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
     public class GetBloodGlucoseRecordByPatientIdQuery : IRequest<Result<ObservationRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetBloodGlucoseRecordByPatientIdQueryHandler : IRequestHandler<GetBloodGlucoseRecordByPatientIdQuery, Result<ObservationRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetBloodGlucoseRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<ObservationRecordDTO>> Handle(GetBloodGlucoseRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bloodGlucoseRecord = await _context.BloodGlucoseTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.BloodGlucoseFrequency != 0,
                    cancellationToken);
                if (bloodGlucoseRecord == null)
                    throw new Exception("Unable to return Blood Glucose Record");

                var dto = new ObservationRecordDTO
                {
                    BloodGlucoseFrequency = bloodGlucoseRecord.BloodGlucoseFrequency,
                    BloodGlucoseSignature = bloodGlucoseRecord.BloodGlucoseSignature,
                    BloodGlucoseTime = bloodGlucoseRecord.BloodGlucoseTime,
                    PatientId = bloodGlucoseRecord.PatientId
                };
                return await Result<ObservationRecordDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<ObservationRecordDTO>.FailAsync(ex.Message);
            }
        }
    }
}
