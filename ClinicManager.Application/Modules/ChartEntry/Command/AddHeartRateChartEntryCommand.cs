using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.ChartEntry.Command
{
    public class AddHeartRateChartEntryCommand : IRequest<Result<int>>
    {
        public int HeartRateChartEntryId { get; set; }
        public double HeartRateChartEntry { get; set; }
        public int HeartRateChartId { get; set; }
    }

    public class AddHeartRateChartEntryCommandHandler : IRequestHandler<AddHeartRateChartEntryCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddHeartRateChartEntryCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddHeartRateChartEntryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var heartRateChartEntry = await _context.HeartRateChartEntries.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.HeartRateChartEntryId, cancellationToken);
                if (heartRateChartEntry != null)
                    throw new Exception("Heart Rate Chart Entry already exists");

                var heartRateChart = await _context.HeartRateCharts.IgnoreQueryFilters()
                                               .FirstOrDefaultAsync(c => c.Id == request.HeartRateChartId, cancellationToken);
                if (heartRateChart == null)
                    throw new Exception("Heart Rate Chart doesn't exist");

                var heartRateChartEnt = new HeartRateChartEntryEntity(
                    request.HeartRateChartEntry,
                    heartRateChart
                    );

                await _context.HeartRateChartEntries.AddAsync(heartRateChartEnt, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(heartRateChartEnt.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
