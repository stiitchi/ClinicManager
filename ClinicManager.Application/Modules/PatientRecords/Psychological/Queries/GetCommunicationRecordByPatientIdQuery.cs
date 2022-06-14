using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological;
using ClinicManager.Shared.DTO_s.Records.Psychological;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Psychological.Queries
{
    public class GetCommunicationRecordByPatientIdQuery : IRequest<Result<List<CommunicationDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetCommunicationRecordByPatientIdQueryHandler : IRequestHandler<GetCommunicationRecordByPatientIdQuery, Result<List<CommunicationDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetCommunicationRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<CommunicationDTO>>> Handle(GetCommunicationRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<CommunicationEntity, CommunicationDTO>> expression = e => new CommunicationDTO
                {
                    CommunicationTime = e.CommunicationTime,
                    CommunicationSignature = e.CommunicationSignature,
                    CommunicationFrequency = e.CommunicationFrequency,
                    PatientId = e.PatientId
                };

                var communicationEntry = await _context.CommunicationTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<CommunicationDTO>>.SuccessAsync(communicationEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<CommunicationDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
