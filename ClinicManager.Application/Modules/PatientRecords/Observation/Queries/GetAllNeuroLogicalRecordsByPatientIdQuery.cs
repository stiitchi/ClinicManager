using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
     public class GetAllNeuroLogicalRecordsByPatientIdQuery : IRequest<Result<List<ObservationRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllNeuroLogicalRecordsByPatientIdQueryHandler : IRequestHandler<GetAllNeuroLogicalRecordsByPatientIdQuery, Result<List<ObservationRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllNeuroLogicalRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<ObservationRecordDTO>>> Handle(GetAllNeuroLogicalRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<NeurologicalEntity, ObservationRecordDTO>> expression = e => new ObservationRecordDTO
                {
                    NeuroLogicalTime = e.NeuroLogicalTime,
                    NeuroLogicalFrequency = e.NeuroLogicalFrequency,
                    NeuroLogicalSignature = e.NeuroLogicalSignature,
                    PatientId = e.PatientId
                };

                var neuroLogicalEntry = await _context.NeurologicalTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.NeuroLogicalFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<ObservationRecordDTO>>.SuccessAsync(neuroLogicalEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<ObservationRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
