using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Charts.Commands
{
    public class AddHeartRateChartCommand : IRequest<Result<int>>
    {
        public int PatientId { get; set; }
        public int HeartRateChartId { get; set; }
        public double HeartRateChartEntry { get; set; }
        public string Time { get; set; }
    }

    public class AddHeartRateChartCommandHandler : IRequestHandler<AddHeartRateChartCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddHeartRateChartCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddHeartRateChartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var heartRateChart = await _context.HeartRateCharts.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.HeartRateChartId, cancellationToken);
                if (heartRateChart != null)
                    throw new Exception(" Heart Rate Chart already exists");

                var patient = await _context.Patients.IgnoreQueryFilters()
                                               .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var heartRateChartEntry = new HeartRateChartEntity(
                    request.HeartRateChartEntry,
                    request.Time,
                    patient
                    );

                await _context.HeartRateCharts.AddAsync(heartRateChartEntry, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(heartRateChartEntry.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
