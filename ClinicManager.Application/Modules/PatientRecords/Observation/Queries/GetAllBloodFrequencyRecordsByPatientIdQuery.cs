using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Shared.DTO_s.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
     public class GetAllBloodFrequencyRecordsByPatientIdQuery : IRequest<Result<List<BloodDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllBloodFrequencyRecordsByPatientIdQueryHandler : IRequestHandler<GetAllBloodFrequencyRecordsByPatientIdQuery, Result<List<BloodDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBloodFrequencyRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<BloodDTO>>> Handle(GetAllBloodFrequencyRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BloodEntity, BloodDTO>> expression = e => new BloodDTO
                {
                    BloodId         = e.Id,
                    BloodFrequency  = e.BloodFrequency,
                    BloodSignature  = e.BloodSignature,
                    BloodTime       = e.BloodTime,
                    PatientId       = e.PatientId
                };

                var bloodGlucoseEntry = await _context.BloodTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<BloodDTO>>.SuccessAsync(bloodGlucoseEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<BloodDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
