using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
     public class GetWoundCareByPatientIdQuery : IRequest<Result<InterventionRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetWoundCareByPatientIdQueryHandler : IRequestHandler<GetWoundCareByPatientIdQuery, Result<InterventionRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetWoundCareByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<InterventionRecordDTO>> Handle(GetWoundCareByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var woundCareEntry = await _context.WoundCareTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.WoundCareFrequency != 0,
                    cancellationToken);
                if (woundCareEntry == null)
                    throw new Exception("Unable to return Wound Care Record");

                var dto = new InterventionRecordDTO
                {
                    WoundCareFreq = woundCareEntry.WoundCareFrequency,
                    WoundCareTime = woundCareEntry.WoundCareTime,
                    WoundCareSignature = woundCareEntry.WoundCareSignature,
                    PatientId = woundCareEntry.PatientId
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
