using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
    public class GetAllTractionRecordsByPatientIdQuery : IRequest<Result<List<InterventionRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllTractionRecordsByPatientIdQueryHandler : IRequestHandler<GetAllTractionRecordsByPatientIdQuery, Result<List<InterventionRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTractionRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<InterventionRecordDTO>>> Handle(GetAllTractionRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<TractionEntity, InterventionRecordDTO>> expression = e => new InterventionRecordDTO
                {
                    TractionFreq = e.TractionFrequency,
                    TractionTime = e.TractionTime,
                    TractionSignature = e.TractionSignature,
                    PatientId = e.PatientId
                };

                var tractionRecords = await _context.TractionTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<InterventionRecordDTO>>.SuccessAsync(tractionRecords);

            }
            catch (Exception ex)
            {
                return await Result<List<InterventionRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
