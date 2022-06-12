using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Psychological.Queries
{
     public class GetHealthEducationByPatientIdQuery : IRequest<Result<List<PsychologicalRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetHealthEducationByPatientIdQueryHandler : IRequestHandler<GetHealthEducationByPatientIdQuery, Result<List<PsychologicalRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetHealthEducationByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<PsychologicalRecordDTO>>> Handle(GetHealthEducationByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<HealthCareEntity, PsychologicalRecordDTO>> expression = e => new PsychologicalRecordDTO
                {
                    HealthEducationSignature = e.HealthEducationSignature,
                    HealthEducationFrequency = e.HealthEducationFrequency,
                    HealthEducationTime = e.HealthEducationTime,
                    PatientId = e.PatientId
                };

                var healthEducationEntry = await _context.HealthCareTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.HealthEducationFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<PsychologicalRecordDTO>>.SuccessAsync(healthEducationEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<PsychologicalRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
