using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.SkinIntegrity.Queries
{
     public class GetPressurePartTimeRecordByPatientIdQuery : IRequest<Result<SkinIntegrityReportDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetPressurePartTimeRecordByPatientIdQueryHandler : IRequestHandler<GetPressurePartTimeRecordByPatientIdQuery, Result<SkinIntegrityReportDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetPressurePartTimeRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<SkinIntegrityReportDTO>> Handle(GetPressurePartTimeRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var pressurePartEntry = await _context.PressurePartRecords.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.PressurePartCareFrequency != 0,
                    cancellationToken);
                if (pressurePartEntry == null)
                    throw new Exception("Unable to return Skin Report");

                var dto = new SkinIntegrityReportDTO
                {
                    PressurePartCareSignature = pressurePartEntry.PressurePartCareSignature,
                    PressurePartCareTime = pressurePartEntry.PressurePartCareTime,
                    PressurePartCareFrequency = pressurePartEntry.PressurePartCareFrequency,
                    PatientId = pressurePartEntry.PatientId
                };
                return await Result<SkinIntegrityReportDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<SkinIntegrityReportDTO>.FailAsync(ex.Message);
            }
        }
    }
}
