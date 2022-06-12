using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
    public class GetVitalSignRecordByPatientIdQuery : IRequest<Result<ObservationRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetVitalSignRecordByPatientIdQueryHandler : IRequestHandler<GetVitalSignRecordByPatientIdQuery, Result<ObservationRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetVitalSignRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<ObservationRecordDTO>> Handle(GetVitalSignRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vitalSignRecord = await _context.VitalSignTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.VitalSignsFrequency != 0,
                    cancellationToken);
                if (vitalSignRecord == null)
                    throw new Exception("Unable to return Vital Sign Record");

                var dto = new ObservationRecordDTO
                {
                    VitalSignsFrequency = vitalSignRecord.VitalSignsFrequency,
                    VitalSignSignature = vitalSignRecord.VitalSignSignature,
                    VitalSignsTime = vitalSignRecord.VitalSignsTime,
                    PatientId = vitalSignRecord.PatientId
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
