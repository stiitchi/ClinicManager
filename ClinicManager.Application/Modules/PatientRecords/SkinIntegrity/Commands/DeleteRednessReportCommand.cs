using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.SkinIntegrity.Commands
{
  public class DeleteRednessReportCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteRednessReportCommandHandler : IRequestHandler<DeleteRednessReportCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRednessReportCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteRednessReportCommand request, CancellationToken cancellationToken)
        {

            var rednessEntry = await _context.RednessTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.RednessTests.Remove(rednessEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(rednessEntry.Id);

        }
    }
}
