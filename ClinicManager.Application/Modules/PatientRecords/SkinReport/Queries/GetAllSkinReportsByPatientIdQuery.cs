using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanSkinIntegrity;
using ClinicManager.Shared.DTO_s.Records.SkinReport;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.SkinReport.Queries
{
    public class GetAllSkinReportsByPatientIdQuery : IRequest<Result<List<SkinReportDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllSkinReportsByPatientIdQueryHandler : IRequestHandler<GetAllSkinReportsByPatientIdQuery, Result<List<SkinReportDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllSkinReportsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<SkinReportDTO>>> Handle(GetAllSkinReportsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<SkinIntegrityReport, SkinReportDTO>> expression = e => new SkinReportDTO
                {
                    SacrumDescription = e.SacrumDescription,
                    HealsDescription = e.HealsDescription,
                    HipsDescription = e.HipsDescription,
                    OtherDescription = e.OtherDescription,
                    Comments = e.Comments,
                    PatientId = e.PatientId
                };

                var skinIntegrity = await _context.SkinIntegrityReports
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<SkinReportDTO>>.SuccessAsync(skinIntegrity);

            }
            catch (Exception ex)
            {
                return await Result<List<SkinReportDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
