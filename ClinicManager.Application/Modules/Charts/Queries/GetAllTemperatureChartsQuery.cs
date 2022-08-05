using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate;
using ClinicManager.Shared.DTO_s.Charts;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Charts.Queries
{
    public class GetAllTemperatureChartsQuery : IRequest<Result<List<TemperatureRateDTO>>>
    {
    }

    public class GetAllTemperatureChartsQueryHandler : IRequestHandler<GetAllTemperatureChartsQuery, Result<List<TemperatureRateDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTemperatureChartsQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<TemperatureRateDTO>>> Handle(GetAllTemperatureChartsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<TemperatureChartEntity, TemperatureRateDTO>> expression = e => new TemperatureRateDTO
                {
                    TempRatetId     = e.Id,
                    TempRateEntry   = e.TempRateEntry,
                    Time            = e.Time,
                    PatientId       = e.PatientId
                };

                var temperatureRates = await _context.TemperatureCharts
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<TemperatureRateDTO>>.SuccessAsync(temperatureRates);

            }
            catch (Exception ex)
            {
                return await Result<List<TemperatureRateDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
