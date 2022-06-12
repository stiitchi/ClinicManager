using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Queries
{
    public class GetBedBathAssistByPatientIdQuery : IRequest<Result<HygieneDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetBedBathAssistByPatientIdQueryHandler : IRequestHandler<GetBedBathAssistByPatientIdQuery, Result<HygieneDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetBedBathAssistByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<HygieneDTO>> Handle(GetBedBathAssistByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bedBathAssistEntry = await _context.BedBathAssistTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.BedBathAssistFrequency != 0, cancellationToken);
                if (bedBathAssistEntry == null)
                    throw new Exception("Unable to return Bed Bath Record");

                var dto = new HygieneDTO
                {
                    BedBathAssistTime = bedBathAssistEntry.BedBathAssistTime,
                    BedBathAssistFreq = bedBathAssistEntry.BedBathAssistFrequency,
                    BedBathAssistSignature = bedBathAssistEntry.BedBathAssistSignature,
                    PatientId = bedBathAssistEntry.PatientId
                };
                return await Result<HygieneDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<HygieneDTO>.FailAsync(ex.Message);
            }
        }
    }
}
