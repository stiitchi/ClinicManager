using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
    public class GetNeuroLogicalRecordByPatientIdQuery : IRequest<Result<NeuroLogicalDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetNeuroLogicalRecordByPatientIdQueryHandler : IRequestHandler<GetNeuroLogicalRecordByPatientIdQuery, Result<NeuroLogicalDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetNeuroLogicalRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<NeuroLogicalDTO>> Handle(GetNeuroLogicalRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var neuroLogicalRecord = await _context.NeurologicalTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.NeuroLogicalFrequency != 0,
                    cancellationToken);
                if (neuroLogicalRecord == null)
                    throw new Exception("Unable to return Neurological Record");

                var dto = new NeuroLogicalDTO
                {
                    NeuroLogicalId          = neuroLogicalRecord.Id,
                    NeuroLogicalFrequency   = neuroLogicalRecord.NeuroLogicalFrequency,
                    NeuroLogicalSignature   = neuroLogicalRecord.NeuroLogicalSignature,
                    NeuroLogicalTime        = neuroLogicalRecord.NeuroLogicalTime,
                    PatientId               = neuroLogicalRecord.PatientId
                };
                return await Result<NeuroLogicalDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<NeuroLogicalDTO>.FailAsync(ex.Message);
            }
        }
    }
}
