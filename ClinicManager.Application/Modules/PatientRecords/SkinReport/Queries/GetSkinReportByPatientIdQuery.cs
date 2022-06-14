using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.SkinReport;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.SkinReport.Queries
{
    public class GetSkinReportByPatientIdQuery : IRequest<Result<SkinReportDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetSkinReportByPatientIdQueryHandler : IRequestHandler<GetSkinReportByPatientIdQuery, Result<SkinReportDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetSkinReportByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<SkinReportDTO>> Handle(GetSkinReportByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var skinIntegrity = await _context.SkinIntegrityReports.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                if (skinIntegrity == null)
                    throw new Exception("Unable to return Skin Report");

                var dto = new SkinReportDTO
                {
                    SacrumDescription = skinIntegrity.SacrumDescription,
                    HealsDescription = skinIntegrity.HealsDescription,
                    HipsDescription = skinIntegrity.HipsDescription,
                    OtherDescription = skinIntegrity.OtherDescription,
                    Comments = skinIntegrity.Comments,
                    PatientId = skinIntegrity.PatientId
                };
                return await Result<SkinReportDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<SkinReportDTO>.FailAsync(ex.Message);
            }
        }
    }
}
