using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Shared.DTO_s.Records.Intervention;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
   public class GetAllIsolationRecordsByPatientIdQuery : IRequest<Result<List<IsolationDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllIsolationRecordsByPatientIdQueryHandler : IRequestHandler<GetAllIsolationRecordsByPatientIdQuery, Result<List<IsolationDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllIsolationRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<IsolationDTO>>> Handle(GetAllIsolationRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<IsolationEntity, IsolationDTO>> expression = e => new IsolationDTO
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
                return await Result<List<IsolationDTO>>.SuccessAsync(isolationRecord);

            }
            catch (Exception ex)
            {
                return await Result<List<IsolationDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
