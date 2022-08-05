using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Charts;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Charts.Queries
{
    public class GetHeartRateChartByIdQuery : IRequest<Result<HeartRateDTO>>
    {
        public int Id { get; set; }
    }

    public class GetHeartRateChartByIdQueryHandler : IRequestHandler<GetHeartRateChartByIdQuery, Result<HeartRateDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetHeartRateChartByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<HeartRateDTO>> Handle(GetHeartRateChartByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var heartRateChart = await _context.HeartRateCharts.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (heartRateChart == null)
                    throw new Exception("Unable to return Heart Rate Chart");

                var dto = new HeartRateDTO
                {
                    HeartRateChartId        = heartRateChart.Id,
                    HeartRateChartEntry     = heartRateChart.HeartRateChartEntry,
                    Time                    = heartRateChart.Time,
                    PatientId               = heartRateChart.PatientId
                };
                return await Result<HeartRateDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<HeartRateDTO>.FailAsync(ex.Message);
            }
        }
    }
}
