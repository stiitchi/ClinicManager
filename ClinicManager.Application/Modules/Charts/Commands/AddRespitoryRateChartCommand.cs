using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Charts.Commands
{
    public class AddRespitoryRateChartCommand : IRequest<Result<int>>
    {
        public int RespitoryChartId { get; set; }
        public int PatientId { get; set; }
        public double RespitoryChartEntry { get; set; }
        public string Time { get; set; }
    }

    public class AddRespitoryRateChartCommandHandler : IRequestHandler<AddRespitoryRateChartCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddRespitoryRateChartCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddRespitoryRateChartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var respitoryRateChart = await _context.RespitoryRateCharts.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.RespitoryChartId, cancellationToken);
                if (respitoryRateChart != null)
                    throw new Exception(" Respitory Rate Chart already exists");

                var patient = await _context.Patients.IgnoreQueryFilters()
                                               .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var respitoryRateChartEntry = new RespitoryRateChartEntity(
                    request.RespitoryChartEntry,
                    request.Time,
                    patient
                    );

                await _context.RespitoryRateCharts.AddAsync(respitoryRateChartEntry, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(respitoryRateChartEntry.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
