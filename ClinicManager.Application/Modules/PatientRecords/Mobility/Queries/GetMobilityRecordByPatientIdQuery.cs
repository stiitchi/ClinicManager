using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Queries
{
    public class GetMobilityRecordByPatientIdQuery : IRequest<Result<MobilityRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetMobilityRecordByPatientIdQueryHandler : IRequestHandler<GetMobilityRecordByPatientIdQuery, Result<MobilityRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetMobilityRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<MobilityRecordDTO>> Handle(GetMobilityRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var mobilityEntry = await _context.MobileImmobileTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.MobileImmobileFrequency != 0,
                    cancellationToken);
                if (mobilityEntry == null)
                    throw new Exception("Unable to return Mobility Record");

                var dto = new MobilityRecordDTO
                {
                    MobileImmobileFreq = mobilityEntry.MobileImmobileFrequency,
                    MobileImmobileSignature = mobilityEntry.MobileImmobileSignature,
                    MobileImmobileTime = mobilityEntry.MobileImmobileTime,
                    PatientId = mobilityEntry.PatientId
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
