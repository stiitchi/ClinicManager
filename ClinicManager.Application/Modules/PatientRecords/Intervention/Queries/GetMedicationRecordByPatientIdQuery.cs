using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Intervention;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
      public class GetMedicationRecordByPatientIdQuery : IRequest<Result<MedicationDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetMedicationRecordByPatientIdQueryHandler : IRequestHandler<GetMedicationRecordByPatientIdQuery, Result<MedicationDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetMedicationRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<MedicationDTO>> Handle(GetMedicationRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var medicationEntry = await _context.MedicationTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.MedicationFrequency != 0,
                    cancellationToken);
                if (medicationEntry == null)
                    throw new Exception("Unable to return Medication Record");

                var dto = new MedicationDTO
                {
                    MedicationId = medicationEntry.Id,
                    MedicationFreq = medicationEntry.MedicationFrequency,
                    MedicationTime = medicationEntry.MedicationTime,
                    MedicationSignature = medicationEntry.MedicationSignature,
                    PatientId = medicationEntry.PatientId
                };
                return await Result<MedicationDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<MedicationDTO>.FailAsync(ex.Message);
            }
        }
    }
}
