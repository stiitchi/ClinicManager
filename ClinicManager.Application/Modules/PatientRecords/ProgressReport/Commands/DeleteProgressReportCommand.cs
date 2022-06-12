using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.ProgressReport.Commands
{
    public class DeleteProgressReportCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteProgressReportCommandHandler : IRequestHandler<DeleteProgressReportCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProgressReportCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteProgressReportCommand request, CancellationToken cancellationToken)
        {

            var progressReport = await _context.PatientProgressTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.PatientProgressTests.Remove(progressReport);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(progressReport.Id);

        }
    }
}
