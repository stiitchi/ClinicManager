using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
     public class GetAllBloodGlucoseRecordsByPatientIdQuery : IRequest<Result<List<ObservationRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllBloodGlucoseRecordsByPatientIdQueryHandler : IRequestHandler<GetAllBloodGlucoseRecordsByPatientIdQuery, Result<List<ObservationRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBloodGlucoseRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<ObservationRecordDTO>>> Handle(GetAllBloodGlucoseRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BloodGlucoseEntity, ObservationRecordDTO>> expression = e => new ObservationRecordDTO
                {
                    BloodGlucoseFrequency = e.BloodGlucoseFrequency,
                    BloodGlucoseSignature = e.BloodGlucoseSignature,
                    BloodGlucoseTime = e.BloodGlucoseTime,
                    PatientId = e.PatientId
                };

                var bloodGlucoseEntry = await _context.BloodGlucoseTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.BloodGlucoseFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<ObservationRecordDTO>>.SuccessAsync(bloodGlucoseEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<ObservationRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
