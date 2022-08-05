using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate;
using ClinicManager.Shared.DTO_s.Charts;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Charts.Queries
{
    public class GetAllHeartRateChartsQuery : IRequest<Result<List<HeartRateDTO>>>
    {
    }

    public class GetAllHeartRateChartsQueryHandler : IRequestHandler<GetAllHeartRateChartsQuery, Result<List<HeartRateDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllHeartRateChartsQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<HeartRateDTO>>> Handle(GetAllHeartRateChartsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<HeartRateChartEntity, HeartRateDTO>> expression = e => new HeartRateDTO
                {
                    HeartRateChartId        = e.Id,
                    HeartRateChartEntry     = e.HeartRateChartEntry,
                    Time                    = e.Time,
                    PatientId               = e.PatientId
                };

                var heartRateCharts = await _context.HeartRateCharts
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<HeartRateDTO>>.SuccessAsync(heartRateCharts);

            }
            catch (Exception ex)
            {
                return await Result<List<HeartRateDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
