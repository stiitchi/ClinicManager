using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.ChartEntry.Command
{
    public class AddRespitoryRateChartEntryCommand : IRequest<Result<int>>
    {
        public int RespitoryRateChartEntryId { get; set; }
        public double RespitoryRateChartEntry { get; set; }
        public int RespitoryRateChartId { get; set; }
    }

    public class AddRespitoryRateChartEntryCommandHandler : IRequestHandler<AddRespitoryRateChartEntryCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddRespitoryRateChartEntryCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddRespitoryRateChartEntryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var respitoryRateChartEntry = await _context.RespitoryRateChartEntries.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.RespitoryRateChartEntryId, cancellationToken);
                if (respitoryRateChartEntry != null)
                    throw new Exception("Respitory Rate Chart Entry already exists");

                var respitoryRateChart = await _context.RespitoryRateCharts.IgnoreQueryFilters()
                                               .FirstOrDefaultAsync(c => c.Id == request.RespitoryRateChartId, cancellationToken);
                if (respitoryRateChart == null)
                    throw new Exception("Respitory Rate Chart doesn't exist");

                var respitoryRateChartEnt = new RespitoryRateChartEntryEntity(
                    request.RespitoryRateChartEntry,
                    respitoryRateChart
                    );

                await _context.RespitoryRateChartEntries.AddAsync(respitoryRateChartEnt, cancellationToken);
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
