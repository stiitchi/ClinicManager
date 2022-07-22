using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.ChartEntry.Command
{
    public class AddBloodPressureChartEntryCommand : IRequest<Result<int>>
    {
        public int BloodPressureChartEntryId { get; set; }
        public double BloodPressureChartEntry { get; set; }
        public int BloodPressureChartId { get; set; }
    }

    public class AddBloodPressureChartEntryCommandHandler : IRequestHandler<AddBloodPressureChartEntryCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddBloodPressureChartEntryCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddBloodPressureChartEntryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bloodPressureChartEntry = await _context.BloodPressureChartEntries.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.BloodPressureChartEntryId, cancellationToken);
                if (bloodPressureChartEntry != null)
                    throw new Exception(" Blood Pressure Chart Entry already exists");

                var bloodPressureChart = await _context.BloodPressureCharts.IgnoreQueryFilters()
                                               .FirstOrDefaultAsync(c => c.Id == request.BloodPressureChartId, cancellationToken);
                if (bloodPressureChart == null)
                    throw new Exception("Blood Pressure Chart doesn't exist");

                var bloodPressChartEntry = new BloodPressureChartEntryEntity(
                    request.BloodPressureChartEntry,
                    bloodPressureChart
                    );

                await _context.BloodPressureChartEntries.AddAsync(bloodPressChartEntry, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(bloodPressChartEntry.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
