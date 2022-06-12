using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.ProgressReport.Queries
{
   public class GetProgressReportByPatientIdQuery : IRequest<Result<ProgressReportDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetProgressReportByPatientIdQueryHandler : IRequestHandler<GetProgressReportByPatientIdQuery, Result<ProgressReportDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetProgressReportByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<ProgressReportDTO>> Handle(GetProgressReportByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var progressReport = await _context.PatientProgressTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);

                if (progressReport == null)
                    throw new Exception("Unable to return Progress Report");
                var dto = new ProgressReportDTO
                {
                   Allergy = progressReport.Allergy,
                   RiskFactor = progressReport.RiskFactor,
                   DateAdded = progressReport.DateAdded,
                   TimeAdded = progressReport.TimeAdded,
                   Desc = progressReport.Description,
                   PatientId = progressReport.PatientId,
                };
                return await Result<ProgressReportDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<ProgressReportDTO>.FailAsync(ex.Message);
            }
        }
    }
}
