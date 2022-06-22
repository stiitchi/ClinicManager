using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Psychological;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Psychological.Queries
{
    public class GetCommunicationRecordByPatientIdQuery : IRequest<Result<CommunicationDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetCommunicationRecordByPatientIdQueryHandler : IRequestHandler<GetCommunicationRecordByPatientIdQuery, Result<CommunicationDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetCommunicationRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<CommunicationDTO>> Handle(GetCommunicationRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var communicationRecord = await _context.CommunicationTests.AsNoTracking()
                   .IgnoreQueryFilters()
                   .FirstOrDefaultAsync(c => c.PatientId == request.PatientId);
                if (communicationRecord == null)
                    throw new Exception("Unable to return Communication Test");

                var dto = new CommunicationDTO
                {
                    CommunicationId = communicationRecord.Id,
                    CommunicationFrequency = communicationRecord.CommunicationFrequency,
                    CommunicationSignature = communicationRecord.CommunicationSignature,
                    CommunicationTime = communicationRecord.CommunicationTime,
                    PatientId = communicationRecord.PatientId
                };
                return await Result<CommunicationDTO>.SuccessAsync(dto);

            }
            catch (Exception ex)
            {
                return await Result<CommunicationDTO>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
