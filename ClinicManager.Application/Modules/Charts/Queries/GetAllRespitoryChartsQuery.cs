using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate;
using ClinicManager.Shared.DTO_s.Charts;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Charts.Queries
{
    public class GetAllRespitoryChartsQuery : IRequest<Result<List<RespitoryChartDTO>>>
    {
    }

    public class GetAllRespitoryChartsQueryHandler : IRequestHandler<GetAllRespitoryChartsQuery, Result<List<RespitoryChartDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllRespitoryChartsQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<RespitoryChartDTO>>> Handle(GetAllRespitoryChartsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<RespitoryRateChartEntity, RespitoryChartDTO>> expression = e => new RespitoryChartDTO
                {
                    RespitoryChartId        = e.Id,
                    RespitoryChartEntry     = e.RespitoryChartEntry,
                    Time                    = e.Time,
                    PatientId               = e.PatientId
                };

                var respitoryCharts = await _context.RespitoryRateCharts
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<RespitoryChartDTO>>.SuccessAsync(respitoryCharts);

            }
            catch (Exception ex)
            {
                return await Result<List<RespitoryChartDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
