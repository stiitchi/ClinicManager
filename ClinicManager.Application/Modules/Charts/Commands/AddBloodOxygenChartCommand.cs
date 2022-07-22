using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Charts.Commands
{
    public class AddBloodOxygenChartCommand : IRequest<Result<int>>
    {
        public int BloodOxygenChartId { get; set; }
        public int PatientId { get; set; }
        public double BloodOxygenChartEntry { get; set; }
        public string Time { get; set; }

    }

    public class AddBloodOxygenChartCommandHandler : IRequestHandler<AddBloodOxygenChartCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddBloodOxygenChartCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddBloodOxygenChartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bloodOxygenChart = await _context.BloodOxygenCharts.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.BloodOxygenChartId, cancellationToken);
                if (bloodOxygenChart != null)
                    throw new Exception(" Blood Oxygen Chart already exists");

                var patient = await _context.Patients.IgnoreQueryFilters()
                                               .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var bloodOxygenChartEntry = new BloodOxygenChartEntity(
                    request.BloodOxygenChartEntry,
                    request.Time,
                    patient
                    );

                await _context.BloodOxygenCharts.AddAsync(bloodOxygenChartEntry, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(bloodOxygenChartEntry.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
