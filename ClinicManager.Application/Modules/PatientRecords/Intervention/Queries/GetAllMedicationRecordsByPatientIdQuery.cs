using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Shared.DTO_s.Records.Intervention;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
    public class GetAllMedicationRecordsByPatientIdQuery : IRequest<Result<List<MedicationDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllMedicationRecordsByPatientIdQueryHandler : IRequestHandler<GetAllMedicationRecordsByPatientIdQuery, Result<List<MedicationDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllMedicationRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<MedicationDTO>>> Handle(GetAllMedicationRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<MedicationEntity, MedicationDTO>> expression = e => new MedicationDTO
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
                return await Result<List<MedicationDTO>>.SuccessAsync(medicationRecord);

            }
            catch (Exception ex)
            {
                return await Result<List<MedicationDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
