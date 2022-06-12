using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.SkinIntegrity.Queries
{
    public class GetRednessRecordByPatientIdQuery : IRequest<Result<SkinIntegrityReportDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetRednessRecordByPatientIdQueryHandler : IRequestHandler<GetRednessRecordByPatientIdQuery, Result<SkinIntegrityReportDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetRednessRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<SkinIntegrityReportDTO>> Handle(GetRednessRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var rednessEntry = await _context.RednessTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.ReportRednessFrequency != 0,
                    cancellationToken);
                if (rednessEntry == null)
                    throw new Exception("Unable to return Redness Skin Report");

                var dto = new SkinIntegrityReportDTO
                {
                    ReportRednessSignature = rednessEntry.ReportRednessSignature,
                    ReportRednessFrequency = rednessEntry.ReportRednessFrequency,
                    ReportRednessTime = rednessEntry.ReportRednessTime,
                    PatientId = rednessEntry.PatientId
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
