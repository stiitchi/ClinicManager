using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Queries
{
    public class GetAllAssistInChairRecordByPatientIdQuery : IRequest<Result<List<MobilityRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllAssistInChairRecordByPatientIdQueryHandler : IRequestHandler<GetAllAssistInChairRecordByPatientIdQuery, Result<List<MobilityRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAssistInChairRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<MobilityRecordDTO>>> Handle(GetAllAssistInChairRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<WalkChairEntity, MobilityRecordDTO>> expression = e => new MobilityRecordDTO
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
                return await Result<List<MobilityRecordDTO>>.SuccessAsync(assistInChairEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<MobilityRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
