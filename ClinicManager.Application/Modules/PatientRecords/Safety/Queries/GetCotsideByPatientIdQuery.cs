using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Safety.Queries
{
      public class GetCotsideByPatientIdQuery : IRequest<Result<SafetyRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetCotsideByPatientIdQueryHandler : IRequestHandler<GetCotsideByPatientIdQuery, Result<SafetyRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetCotsideByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<SafetyRecordDTO>> Handle(GetCotsideByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cotsideEntry = await _context.CotsideRecords.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.CotsidesFrequency != 0,
                    cancellationToken);
                if (cotsideEntry == null)
                    throw new Exception("Unable to return Cotside Record");

                var dto = new SafetyRecordDTO
                {
                    CotsidesTime = cotsideEntry.CotsidesTime,
                    CotsidesSignature = cotsideEntry.CotsidesSignature,
                    CotsidesFrequency = cotsideEntry.CotsidesFrequency,
                    PatientId = cotsideEntry.PatientId
                };
                return await Result<SafetyRecordDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<SafetyRecordDTO>.FailAsync(ex.Message);
            }
        }
    }
}
