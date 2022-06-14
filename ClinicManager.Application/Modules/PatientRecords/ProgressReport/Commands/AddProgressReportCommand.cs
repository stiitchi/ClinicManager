using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.ProgressRecords;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.ProgressReport.Commands
{
 public class AddProgressReportCommand : IRequest<Result<int>>
    {
        public string Allergy { get; set; }
        public string Desc { get; set; }
        public string RiskFactor { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime TimeAdded { get; set; }
        public int PatientId { get; set; }
        public int ProgressReportId { get; set; }
    }

    public class AddProgressHandlersReportCommand : IRequestHandler<AddProgressReportCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddProgressHandlersReportCommand(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddProgressReportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var progressReport = await _context.PatientProgressTests.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.ProgressReportId && c.PatientId == request.PatientId
                                                 ,cancellationToken);
                if (progressReport != null)
                    throw new Exception("Report already exists");

                var patient = await _context.Patients.IgnoreQueryFilters()
                                               .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var progReport = new PatientProgressEntity(
                   request.Allergy,
                   request.Desc,
                   request.RiskFactor,
                   request.DateAdded,
                   request.TimeAdded,
                   patient
                    );

                await _context.PatientProgressTests.AddAsync(progReport, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(progReport.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
