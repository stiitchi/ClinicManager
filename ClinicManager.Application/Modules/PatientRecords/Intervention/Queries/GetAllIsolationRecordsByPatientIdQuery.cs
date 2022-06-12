using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
   public class GetAllIsolationRecordsByPatientIdQuery : IRequest<Result<List<InterventionRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllIsolationRecordsByPatientIdQueryHandler : IRequestHandler<GetAllIsolationRecordsByPatientIdQuery, Result<List<InterventionRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllIsolationRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<InterventionRecordDTO>>> Handle(GetAllIsolationRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<IsolationEntity, InterventionRecordDTO>> expression = e => new InterventionRecordDTO
                {
                    IsolationFreq = e.IsolationFrequency,
                    IsolationTime = e.IsolationTime,
                    IsolationSignature = e.IsolationSignature,
                    PatientId = e.PatientId
                };

                var isolationRecord = await _context.IsolationTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<InterventionRecordDTO>>.SuccessAsync(isolationRecord);

            }
            catch (Exception ex)
            {
                return await Result<List<InterventionRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
