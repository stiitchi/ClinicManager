using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using ClinicManager.Shared.DTO_s.Records.Mobility;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Queries
{
    public class GetAllAssistInChairRecordByPatientIdQuery : IRequest<Result<List<AssistIntoChairDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllAssistInChairRecordByPatientIdQueryHandler : IRequestHandler<GetAllAssistInChairRecordByPatientIdQuery, Result<List<AssistIntoChairDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAssistInChairRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<AssistIntoChairDTO>>> Handle(GetAllAssistInChairRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<WalkChairEntity, AssistIntoChairDTO>> expression = e => new AssistIntoChairDTO
                {
                    AssistIntoChairTime = e.AssistIntoChairTime,
                    AssistIntoChairFrequency = e.AssistIntoChairFrequency,
                    AssistIntoChairSignature = e.AssistIntoChairSignature,
                    PatientId = e.PatientId
                };

                var assistInChairEntry = await _context.WalkChairTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.AssistIntoChairFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<AssistIntoChairDTO>>.SuccessAsync(assistInChairEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<AssistIntoChairDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
