using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.ChartEntry.Command
{
    public class AddBloodOxygenChartEntryCommand : IRequest<Result<int>>
    {
        public int BloodOxygenChartEntryId { get; set; }
        public int BloodOxygenChartId { get; set; }
        public double BloodOxygenChartEntry { get; set; }

    }

    public class AddBloodOxygenChartEntryCommandHandler : IRequestHandler<AddBloodOxygenChartEntryCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddBloodOxygenChartEntryCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddBloodOxygenChartEntryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bloodOxygenChartEntry = await _context.BloodOxygenChartEntries.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.BloodOxygenChartEntryId, cancellationToken);
                if (bloodOxygenChartEntry != null)
                    throw new Exception(" Blood Oxygen Chart Entry already exists");

                var bloodOxygenChart = await _context.BloodOxygenCharts.IgnoreQueryFilters()
                                               .FirstOrDefaultAsync(c => c.Id == request.BloodOxygenChartId, cancellationToken);
                if (bloodOxygenChart == null)
                    throw new Exception("Blood Oxygen Chart doesn't exist");

                var bloodOxyChartEntry = new BloodOxygenChartEntryEntity(
                    request.BloodOxygenChartEntry,
                    bloodOxygenChart
                    );

                await _context.BloodOxygenChartEntries.AddAsync(bloodOxyChartEntry, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(bloodOxyChartEntry.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
