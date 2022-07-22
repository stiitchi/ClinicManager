using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Charts.Commands
{
    public class AddTemperatureRateCommand : IRequest<Result<int>>
    {
        public int TempRatetId { get; set; }
        public int PatientId { get; set; }
        public double TempRateEntry { get; set; }
        public string Time { get; set; }
    }

    public class AddTemperatureRateCommandHandler : IRequestHandler<AddTemperatureRateCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddTemperatureRateCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddTemperatureRateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var temperatureRateChart = await _context.TemperatureCharts.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.TempRatetId, cancellationToken);
                if (temperatureRateChart != null)
                    throw new Exception("Temperature Rate Chart already exists");

                var patient = await _context.Patients.IgnoreQueryFilters()
                                               .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var temperatureRateChartEntry = new TemperatureChartEntity(
                    request.TempRateEntry,
                    request.Time,
                    patient
                    );

                await _context.TemperatureCharts.AddAsync(temperatureRateChartEntry, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(temperatureRateChartEntry.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
