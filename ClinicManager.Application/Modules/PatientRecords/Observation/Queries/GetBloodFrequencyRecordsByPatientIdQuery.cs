using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Shared.DTO_s.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
     public class GetBloodFrequencyRecordByPatientIdQuery : IRequest<Result<List<BloodDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetBloodFrequencyRecordByPatientIdQueryHandler : IRequestHandler<GetBloodFrequencyRecordByPatientIdQuery, Result<List<BloodDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetBloodFrequencyRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<BloodDTO>>> Handle(GetBloodFrequencyRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BloodEntity, BloodDTO>> expression = e => new BloodDTO
                {
                    BloodFrequency = e.BloodFrequency,
                    BloodSignature = e.BloodSignature,
                    BloodTime = e.BloodTime,
                    PatientId = e.PatientId
                };

                var bloodEntry = await _context.BloodTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<BloodDTO>>.SuccessAsync(bloodEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<BloodDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
