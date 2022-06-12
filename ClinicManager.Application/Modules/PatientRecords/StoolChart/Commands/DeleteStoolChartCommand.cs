using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.StoolChart.Commands
{
    public class DeleteStoolChartCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteStoolChartCommandHandler : IRequestHandler<DeleteStoolChartCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteStoolChartCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteStoolChartCommand request, CancellationToken cancellationToken)
        {
            var stoolChart = await _context.StoolChartTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.StoolChartTests.Remove(stoolChart);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(stoolChart.Id);
        }
    }
}
