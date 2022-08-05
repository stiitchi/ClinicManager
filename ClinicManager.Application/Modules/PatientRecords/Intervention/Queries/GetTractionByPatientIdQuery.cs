using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Intervention;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
     public class GetTractionByPatientIdQuery : IRequest<Result<TractionDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetTractionByPatientIdQueryHandler : IRequestHandler<GetTractionByPatientIdQuery, Result<TractionDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetTractionByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<TractionDTO>> Handle(GetTractionByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tractionEntry = await _context.TractionTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.TractionFrequency != 0,
                    cancellationToken);
                if (tractionEntry == null)
                    throw new Exception("Unable to return Traction Record");

                var dto = new TractionDTO
                {
                    TractionId        = tractionEntry.Id,
                    TractionFreq      = tractionEntry.TractionFrequency,
                    TractionTime      = tractionEntry.TractionTime,
                    TractionSignature = tractionEntry.TractionSignature,
                    PatientId         = tractionEntry.PatientId
                };
                return await Result<TractionDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<TractionDTO>.FailAsync(ex.Message);
            }
        }
    }
}
