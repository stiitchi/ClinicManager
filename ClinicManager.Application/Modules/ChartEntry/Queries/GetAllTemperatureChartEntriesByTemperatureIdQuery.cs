using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Shared.DTO_s.Charts.ChartEntry;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.ChartEntry.Queries
{
    public class GetAllTemperatureChartEntriesByTemperatureIdQuery : IRequest<Result<List<TemperatureRateEntryDTO>>>
    {
        public int TemperatureChartId { get; set; }
    }

    public class GetAllTemperatureChartEntriesByTemperatureIdQueryHandler : IRequestHandler<GetAllTemperatureChartEntriesByTemperatureIdQuery, Result<List<TemperatureRateEntryDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTemperatureChartEntriesByTemperatureIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<TemperatureRateEntryDTO>>> Handle(GetAllTemperatureChartEntriesByTemperatureIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<TemperatureChartEntryEntity, TemperatureRateEntryDTO>> expression = e => new TemperatureRateEntryDTO
                {
                    TemperatureRateEntryId = e.Id,
                    TemperatureRateId = e.TemperatureChartId,
                    TemperatureRateEntry = e.TemperatureChartEntry
                };

                var respitoryRateChartEntries = await _context.TemperatureChartEntries
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Where(x => x.TemperatureChartId == request.TemperatureChartId)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<TemperatureRateEntryDTO>>.SuccessAsync(respitoryRateChartEntries);
            }
            catch (Exception ex)
            {
                return await Result<List<TemperatureRateEntryDTO>>.FailAsync(ex.Message);
            }
        }
    }
}
