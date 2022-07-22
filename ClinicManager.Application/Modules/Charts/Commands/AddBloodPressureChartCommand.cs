using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Charts.Commands
{
    public class AddBloodPressureChartCommand : IRequest<Result<int>>
    {
        public int PatientId { get; set; }
        public int BloodPressureChartId { get; set; }
        public double BloodPressureChartEntry { get; set; }
        public string Time { get; set; }
    }

    public class AddBloodPressureChartCommandHandler : IRequestHandler<AddBloodPressureChartCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddBloodPressureChartCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddBloodPressureChartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bloodPressureChart = await _context.BloodPressureCharts.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.BloodPressureChartId, cancellationToken);
                if (bloodPressureChart != null)
                    throw new Exception(" Blood Pressure Chart already exists");

                var patient = await _context.Patients.IgnoreQueryFilters()
                                               .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var bloodPressureChartEntry = new BloodPressureChartEntity(
                    request.BloodPressureChartEntry,
                    request.Time,
                    patient
                    );

                await _context.BloodPressureCharts.AddAsync(bloodPressureChartEntry, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(bloodPressureChartEntry.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
