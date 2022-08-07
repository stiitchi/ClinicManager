using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Shared.DTO_s.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
     public class GetAllBloodGlucoseRecordsByPatientIdQuery : IRequest<Result<List<BloodGlucoseDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllBloodGlucoseRecordsByPatientIdQueryHandler : IRequestHandler<GetAllBloodGlucoseRecordsByPatientIdQuery, Result<List<BloodGlucoseDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBloodGlucoseRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<BloodGlucoseDTO>>> Handle(GetAllBloodGlucoseRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BloodGlucoseEntity, BloodGlucoseDTO>> expression = e => new BloodGlucoseDTO
                {
                    BloodGlucoseId          = e.Id,
                    BloodGlucoseFrequency   = e.BloodGlucoseFrequency,
                    BloodGlucoseSignature   = e.BloodGlucoseSignature,
                    BloodGlucoseTime        = e.BloodGlucoseTime,
                    PatientId               = e.PatientId
                };

                var bloodGlucoseEntry = await _context.BloodGlucoseTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .OrderByDescending(x => x.BloodGlucoseTime)
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.BloodGlucoseFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<BloodGlucoseDTO>>.SuccessAsync(bloodGlucoseEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<BloodGlucoseDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
