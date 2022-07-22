using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.ChartEntry.Command
{
    public class AddTemperatureChartEntryCommand : IRequest<Result<int>>
    {
        public int TemperatureRateEntryId { get; set; }
        public double TemperatureRateEntry { get; set; }
        public int TemperatureRateId { get; set; }
    }

    public class AddTemperatureChartEntryCommandHandler : IRequestHandler<AddTemperatureChartEntryCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddTemperatureChartEntryCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddTemperatureChartEntryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var temperatureRateChartEntry = await _context.TemperatureChartEntries.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.TemperatureRateEntryId, cancellationToken);
                if (temperatureRateChartEntry != null)
                    throw new Exception("Temperature Rate Chart Entry already exists");

                var temperatureRateChart = await _context.TemperatureCharts.IgnoreQueryFilters()
                                               .FirstOrDefaultAsync(c => c.Id == request.TemperatureRateId, cancellationToken);
                if (temperatureRateChart == null)
                    throw new Exception("Temperature Rate Chart doesn't exist");

                var respitoryRateChartEnt = new TemperatureChartEntryEntity(
                    request.TemperatureRateEntry,
                    temperatureRateChart
                    );

                await _context.TemperatureChartEntries.AddAsync(respitoryRateChartEnt, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(respitoryRateChartEnt.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
