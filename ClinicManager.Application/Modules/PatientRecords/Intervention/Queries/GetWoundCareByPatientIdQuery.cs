using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Intervention;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
     public class GetWoundCareByPatientIdQuery : IRequest<Result<WoundCareDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetWoundCareByPatientIdQueryHandler : IRequestHandler<GetWoundCareByPatientIdQuery, Result<WoundCareDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetWoundCareByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<WoundCareDTO>> Handle(GetWoundCareByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var woundCareEntry = await _context.WoundCareTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.WoundCareFrequency != 0,
                    cancellationToken);
                if (woundCareEntry == null)
                    throw new Exception("Unable to return Wound Care Record");

                var dto = new WoundCareDTO
                {
                    WoundCareId = woundCareEntry.Id,
                    WoundCareFreq = woundCareEntry.WoundCareFrequency,
                    WoundCareTime = woundCareEntry.WoundCareTime,
                    WoundCareSignature = woundCareEntry.WoundCareSignature,
                    PatientId = woundCareEntry.PatientId
                };
                return await Result<WoundCareDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<WoundCareDTO>.FailAsync(ex.Message);
            }
        }
    }
}
