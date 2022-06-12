using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
    public class GetAllMedicationRecordsByPatientIdQuery : IRequest<Result<List<InterventionRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllMedicationRecordsByPatientIdQueryHandler : IRequestHandler<GetAllMedicationRecordsByPatientIdQuery, Result<List<InterventionRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllMedicationRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<InterventionRecordDTO>>> Handle(GetAllMedicationRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<MedicationEntity, InterventionRecordDTO>> expression = e => new InterventionRecordDTO
                {
                    MedicationFreq = e.MedicationFrequency,
                    MedicationTime = e.MedicationTime,
                    MedicationSignature = e.MedicationSignature,
                    PatientId = e.PatientId
                };

                var medicationRecord = await _context.MedicationTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<InterventionRecordDTO>>.SuccessAsync(medicationRecord);

            }
            catch (Exception ex)
            {
                return await Result<List<InterventionRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
