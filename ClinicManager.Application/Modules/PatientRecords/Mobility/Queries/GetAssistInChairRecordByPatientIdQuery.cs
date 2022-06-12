using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Queries
{
     public class GetAssistInChairRecordByPatientIdQuery : IRequest<Result<MobilityRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetAssistInChairRecordByPatientIdQueryHandler : IRequestHandler<GetAssistInChairRecordByPatientIdQuery, Result<MobilityRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAssistInChairRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<MobilityRecordDTO>> Handle(GetAssistInChairRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var chairAssistEntry = await _context.WalkChairTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.AssistIntoChairFrequency != 0,
                    cancellationToken);
                if (chairAssistEntry == null)
                    throw new Exception("Unable to return Chair Assistance Record");

                var dto = new MobilityRecordDTO
                {
                    AssistIntoChairFrequency = chairAssistEntry.AssistIntoChairFrequency,
                    AssistIntoChairSignature = chairAssistEntry.AssistIntoChairSignature,
                    AssistIntoChairTime = chairAssistEntry.AssistIntoChairTime,
                    PatientId = chairAssistEntry.PatientId
                };
                return await Result<MobilityRecordDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<MobilityRecordDTO>.FailAsync(ex.Message);
            }
        }
    }
}
