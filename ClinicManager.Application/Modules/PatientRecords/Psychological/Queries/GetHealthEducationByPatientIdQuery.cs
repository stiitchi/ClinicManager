using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Psychological;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Psychological.Queries
{
     public class GetHealthEducationByPatientIdQuery : IRequest<Result<HealthEducationDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetHealthEducationByPatientIdQueryHandler : IRequestHandler<GetHealthEducationByPatientIdQuery, Result<HealthEducationDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetHealthEducationByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<HealthEducationDTO>> Handle(GetHealthEducationByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var healthEducationRecord = await _context.HealthCareTests.AsNoTracking()
                  .IgnoreQueryFilters()
                  .FirstOrDefaultAsync(c => c.PatientId == request.PatientId);
                if (healthEducationRecord == null)
                    throw new Exception("Unable to return Health Education Record");

                var dto = new HealthEducationDTO
                {
                    HealthEducationId = healthEducationRecord.Id,
                    HealthEducationFrequency = healthEducationRecord.HealthEducationFrequency,
                    HealthEducationSignature = healthEducationRecord.HealthEducationSignature,
                    HealthEducationTime = healthEducationRecord.HealthEducationTime,
                    PatientId = healthEducationRecord.PatientId
                };
                return await Result<HealthEducationDTO>.SuccessAsync(dto);

            }
            catch (Exception ex)
            {
                return await Result<HealthEducationDTO>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
