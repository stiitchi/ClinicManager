using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.ProgressRecords;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.ProgressReport.Queries
{
  public class GetAllProgressReportsByPatientIdQuery : IRequest<Result<List<ProgressReportDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllProgressReportsByPatientIdQueryHandler : IRequestHandler<GetAllProgressReportsByPatientIdQuery, Result<List<ProgressReportDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllProgressReportsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<ProgressReportDTO>>> Handle(GetAllProgressReportsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PatientProgressEntity, ProgressReportDTO>> expression = e => new ProgressReportDTO
                {
                    ProgressReportId = e.Id,
                    Allergy          = e.Allergy,
                    DateAdded        = e.DateAdded,
                    Desc             = e.Description,
                    RiskFactor       = e.RiskFactor,
                    TimeAdded        = e.TimeAdded,
                    PatientId        = e.PatientId,
                };

                var progressReport = await _context.PatientProgressTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .OrderByDescending(x => x.DateAdded)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<ProgressReportDTO>>.SuccessAsync(progressReport);

            }
            catch (Exception ex)
            {
                return await Result<List<ProgressReportDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
