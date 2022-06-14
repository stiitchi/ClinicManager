using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Safety;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Safety.Queries
{
    public class GetCheckIDBandRecordByPatientIdQuery : IRequest<Result<CheckIDBandDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetCheckIDBandRecordByPatientIdQueryHandler : IRequestHandler<GetCheckIDBandRecordByPatientIdQuery, Result<CheckIDBandDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetCheckIDBandRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<CheckIDBandDTO>> Handle(GetCheckIDBandRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var idBandEntry = await _context.CheckIdBandTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.CheckIDBandsFrequency != 0,
                    cancellationToken);
                if (idBandEntry == null)
                    throw new Exception("Unable to return ID Band Record");

                var dto = new CheckIDBandDTO
                {
                    CheckIDBandsTime = idBandEntry.CheckIDBandsTime,
                    CheckIDBandsSignature = idBandEntry.CheckIDBandsSignature,
                    CheckIDBandsFrequency = idBandEntry.CheckIDBandsFrequency,
                    PatientId = idBandEntry.PatientId
                };
                return await Result<CheckIDBandDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<CheckIDBandDTO>.FailAsync(ex.Message);
            }
        }
    }
}
