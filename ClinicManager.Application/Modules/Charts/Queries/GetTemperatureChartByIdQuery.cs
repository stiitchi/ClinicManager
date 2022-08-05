using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Charts;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Charts.Queries
{
    public class GetTemperatureChartByIdQuery : IRequest<Result<TemperatureRateDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTemperatureChartByIdQueryHandler : IRequestHandler<GetTemperatureChartByIdQuery, Result<TemperatureRateDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetTemperatureChartByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<TemperatureRateDTO>> Handle(GetTemperatureChartByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var temperatureRateChart = await _context.RespitoryRateCharts.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (temperatureRateChart == null)
                    throw new Exception("Unable to return Temperature Chart");

                var dto = new TemperatureRateDTO
                {
                    TempRatetId   = temperatureRateChart.Id,
                    TempRateEntry = temperatureRateChart.RespitoryChartEntry,
                    Time          = temperatureRateChart.Time,
                    PatientId     = temperatureRateChart.PatientId
                };
                return await Result<TemperatureRateDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<TemperatureRateDTO>.FailAsync(ex.Message);
            }
        }
    }
}
