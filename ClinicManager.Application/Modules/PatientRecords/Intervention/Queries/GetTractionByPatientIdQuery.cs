using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
     public class GetTractionByPatientIdQuery : IRequest<Result<InterventionRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetTractionByPatientIdQueryHandler : IRequestHandler<GetTractionByPatientIdQuery, Result<InterventionRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetTractionByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<InterventionRecordDTO>> Handle(GetTractionByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tractionEntry = await _context.TractionTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.TractionFrequency != 0,
                    cancellationToken);
                if (tractionEntry == null)
                    throw new Exception("Unable to return Traction Record");

                var dto = new InterventionRecordDTO
                {
                    TractionFreq = tractionEntry.TractionFrequency,
                    TractionTime = tractionEntry.TractionTime,
                    TractionSignature = tractionEntry.TractionSignature,
                    PatientId = tractionEntry.PatientId
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
