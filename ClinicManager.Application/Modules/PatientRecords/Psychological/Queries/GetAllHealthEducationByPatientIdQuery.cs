using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological;
using ClinicManager.Shared.DTO_s.Records.Psychological;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Psychological.Queries
{
    public class GetAllHealthEducationByPatientIdQuery : IRequest<Result<List<HealthEducationDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllHealthEducationByPatientIdQueryHandler : IRequestHandler<GetAllHealthEducationByPatientIdQuery, Result<List<HealthEducationDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllHealthEducationByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<HealthEducationDTO>>> Handle(GetAllHealthEducationByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<HealthCareEntity, HealthEducationDTO>> expression = e => new HealthEducationDTO
                {
                    HealthEducationId           = e.Id,
                    HealthEducationTime         = e.HealthEducationTime,
                    HealthEducationFrequency    = e.HealthEducationFrequency,
                    HealthEducationSignature    = e.HealthEducationSignature,
                    PatientId                   = e.PatientId
                };

                var heatlhEntry = await _context.HealthCareTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.HealthEducationFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<HealthEducationDTO>>.SuccessAsync(heatlhEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<HealthEducationDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
