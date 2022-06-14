using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
    public class GetVitalSignRecordByPatientIdQuery : IRequest<Result<VitalSignDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetVitalSignRecordByPatientIdQueryHandler : IRequestHandler<GetVitalSignRecordByPatientIdQuery, Result<VitalSignDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetVitalSignRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<VitalSignDTO>> Handle(GetVitalSignRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vitalSignRecord = await _context.VitalSignTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.VitalSignsFrequency != 0,
                    cancellationToken);
                if (vitalSignRecord == null)
                    throw new Exception("Unable to return Vital Sign Record");

                var dto = new VitalSignDTO
                {
                    VitalSignsFrequency = vitalSignRecord.VitalSignsFrequency,
                    VitalSignSignature = vitalSignRecord.VitalSignSignature,
                    VitalSignsTime = vitalSignRecord.VitalSignsTime,
                    PatientId = vitalSignRecord.PatientId
                };
                return await Result<VitalSignDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<VitalSignDTO>.FailAsync(ex.Message);
            }
        }
    }
}
