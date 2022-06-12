using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Psychological.Queries
{
    public class GetAllCommunicationRecordsByPatientIdQuery : IRequest<Result<List<PsychologicalRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllCommunicationRecordsByPatientIdQueryHandler : IRequestHandler<GetAllCommunicationRecordsByPatientIdQuery, Result<List<PsychologicalRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCommunicationRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<PsychologicalRecordDTO>>> Handle(GetAllCommunicationRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<CommunicationEntity, PsychologicalRecordDTO>> expression = e => new PsychologicalRecordDTO
                {
                    CommunicationFrequency = e.CommunicationFrequency,
                    CommunicationSignature = e.CommunicationSignature,
                    CommunicationTime = e.CommunicationTime,
                    PatientId = e.PatientId
                };

                var communicationEntry = await _context.CommunicationTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.CommunicationFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<PsychologicalRecordDTO>>.SuccessAsync(communicationEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<PsychologicalRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
