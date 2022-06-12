using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.SkinReport.Commands
{
    public class DeleteSkinReportCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSkinReportCommandHandler : IRequestHandler<DeleteSkinReportCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSkinReportCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteSkinReportCommand request, CancellationToken cancellationToken)
        {

            var skinReport = await _context.SkinIntegrityReports.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.SkinIntegrityReports.Remove(skinReport);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(skinReport.Id);

        }
    }
}
