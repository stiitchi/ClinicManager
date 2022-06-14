using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Mobility;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Queries
{
     public class GetAssistInChairRecordByPatientIdQuery : IRequest<Result<AssistIntoChairDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetAssistInChairRecordByPatientIdQueryHandler : IRequestHandler<GetAssistInChairRecordByPatientIdQuery, Result<AssistIntoChairDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAssistInChairRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<AssistIntoChairDTO>> Handle(GetAssistInChairRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var chairAssistEntry = await _context.WalkChairTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.AssistIntoChairFrequency != 0,
                    cancellationToken);
                if (chairAssistEntry == null)
                    throw new Exception("Unable to return Chair Assistance Record");

                var dto = new AssistIntoChairDTO
                {
                    AssistIntoChairFrequency = chairAssistEntry.AssistIntoChairFrequency,
                    AssistIntoChairSignature = chairAssistEntry.AssistIntoChairSignature,
                    AssistIntoChairTime = chairAssistEntry.AssistIntoChairTime,
                    PatientId = chairAssistEntry.PatientId
                };
                return await Result<AssistIntoChairDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<AssistIntoChairDTO>.FailAsync(ex.Message);
            }
        }
    }
}
