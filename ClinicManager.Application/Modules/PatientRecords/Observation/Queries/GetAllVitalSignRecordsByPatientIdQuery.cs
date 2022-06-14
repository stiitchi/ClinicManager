using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Shared.DTO_s.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
     public class GetAllVitalSignRecordsByPatientIdQuery : IRequest<Result<List<VitalSignDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllVitalSignRecordsByPatientIdQueryHandler : IRequestHandler<GetAllVitalSignRecordsByPatientIdQuery, Result<List<VitalSignDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllVitalSignRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<VitalSignDTO>>> Handle(GetAllVitalSignRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<VitalSignEntity, VitalSignDTO>> expression = e => new VitalSignDTO
                {
                    VitalSignsTime = e.VitalSignsTime,
                    VitalSignSignature = e.VitalSignSignature,
                    VitalSignsFrequency = e.VitalSignsFrequency,
                    PatientId = e.PatientId
                };

                var vitalSignsEntry = await _context.VitalSignTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<VitalSignDTO>>.SuccessAsync(vitalSignsEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<VitalSignDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
