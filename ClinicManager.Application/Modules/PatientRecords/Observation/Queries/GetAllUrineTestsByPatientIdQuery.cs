using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Shared.DTO_s.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
    public class GetAllUrineTestsByPatientIdQuery : IRequest<Result<List<UrineTestDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllUrineTestsByPatientIdQueryHandler : IRequestHandler<GetAllUrineTestsByPatientIdQuery, Result<List<UrineTestDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllUrineTestsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<UrineTestDTO>>> Handle(GetAllUrineTestsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<UrineTestEntity, UrineTestDTO>> expression = e => new UrineTestDTO
                {
                    UrineTestId = e.Id,
                    UrineTestFrequency = e.UrineTestFrequency,
                    UrineTestSignature = e.UrineTestSignature,
                    UrineTestTime = e.UrineTestTime,
                    PatientId = e.PatientId
                };

                var urineTestEntry = await _context.UrineTestTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.UrineTestFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<UrineTestDTO>>.SuccessAsync(urineTestEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<UrineTestDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
