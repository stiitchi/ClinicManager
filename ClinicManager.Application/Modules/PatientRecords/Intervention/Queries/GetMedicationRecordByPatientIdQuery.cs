using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
      public class GetMedicationRecordByPatientIdQuery : IRequest<Result<InterventionRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetMedicationRecordByPatientIdQueryHandler : IRequestHandler<GetMedicationRecordByPatientIdQuery, Result<InterventionRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetMedicationRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<InterventionRecordDTO>> Handle(GetMedicationRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var medicationEntry = await _context.MedicationTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.MedicationFrequency != 0,
                    cancellationToken);
                if (medicationEntry == null)
                    throw new Exception("Unable to return Medication Record");

                var dto = new InterventionRecordDTO
                {
                    MedicationFreq = medicationEntry.MedicationFrequency,
                    MedicationTime = medicationEntry.MedicationTime,
                    MedicationSignature = medicationEntry.MedicationSignature,
                    PatientId = medicationEntry.PatientId
                };
                return await Result<InterventionRecordDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<InterventionRecordDTO>.FailAsync(ex.Message);
            }
        }
    }
}
