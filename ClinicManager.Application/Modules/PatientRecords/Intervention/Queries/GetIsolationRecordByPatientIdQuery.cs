using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
   public class GetIsolationRecordByPatientIdQuery : IRequest<Result<InterventionRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetIsolationRecordByPatientIdQueryHandler : IRequestHandler<GetIsolationRecordByPatientIdQuery, Result<InterventionRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetIsolationRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<InterventionRecordDTO>> Handle(GetIsolationRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var isolationEntry = await _context.IsolationTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.IsolationFrequency != 0,
                    cancellationToken);
                if (isolationEntry == null)
                    throw new Exception("Unable to return Isolation Record");

                var dto = new InterventionRecordDTO
                {
                    IsolationFreq = isolationEntry.IsolationFrequency,
                    IsolationTime = isolationEntry.IsolationTime,
                    IsolationSignature = isolationEntry.IsolationSignature,
                    PatientId = isolationEntry.PatientId
                };
                return await Result<InterventionRecordDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<InterventionRecordDTO>.FailAsync(ex.Message);
            }
        }
    }
}
