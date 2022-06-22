using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Mobility;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Queries
{
    public class GetMobilityRecordByPatientIdQuery : IRequest<Result<MobileImmobileDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetMobilityRecordByPatientIdQueryHandler : IRequestHandler<GetMobilityRecordByPatientIdQuery, Result<MobileImmobileDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetMobilityRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<MobileImmobileDTO>> Handle(GetMobilityRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var mobilityEntry = await _context.MobileImmobileTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.MobileImmobileFrequency != 0,
                    cancellationToken);
                if (mobilityEntry == null)
                    throw new Exception("Unable to return Mobility Record");

                var dto = new MobileImmobileDTO
                {
                    MobileImmobileId = mobilityEntry.Id,
                    MobileImmobileFreq = mobilityEntry.MobileImmobileFrequency,
                    MobileImmobileSignature = mobilityEntry.MobileImmobileSignature,
                    MobileImmobileTime = mobilityEntry.MobileImmobileTime,
                    PatientId = mobilityEntry.PatientId
                };
                return await Result<MobileImmobileDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<MobileImmobileDTO>.FailAsync(ex.Message);
            }
        }
    }
}
