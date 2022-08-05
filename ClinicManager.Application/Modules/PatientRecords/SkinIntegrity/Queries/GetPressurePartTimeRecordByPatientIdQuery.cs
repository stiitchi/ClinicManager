using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.SkinIntegrity;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.SkinIntegrity.Queries
{
     public class GetPressurePartTimeRecordByPatientIdQuery : IRequest<Result<PressurePartCareDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetPressurePartTimeRecordByPatientIdQueryHandler : IRequestHandler<GetPressurePartTimeRecordByPatientIdQuery, Result<PressurePartCareDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetPressurePartTimeRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<PressurePartCareDTO>> Handle(GetPressurePartTimeRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var pressurePartEntry = await _context.PressurePartRecords.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.PressurePartCareFrequency != 0,
                    cancellationToken);
                if (pressurePartEntry == null)
                    throw new Exception("Unable to return Skin Report");

                var dto = new PressurePartCareDTO
                {
                    PressurePartCareSignature = pressurePartEntry.PressurePartCareSignature,
                    PressurePartCareTime      = pressurePartEntry.PressurePartCareTime,
                    PressurePartCareFrequency = pressurePartEntry.PressurePartCareFrequency,
                    PatientId                 = pressurePartEntry.PatientId
                };
                return await Result<PressurePartCareDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<PressurePartCareDTO>.FailAsync(ex.Message);
            }
        }
    }
}
