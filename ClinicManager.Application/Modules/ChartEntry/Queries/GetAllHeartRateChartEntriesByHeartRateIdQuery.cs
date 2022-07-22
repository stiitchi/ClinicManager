using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Shared.DTO_s.Charts.ChartEntry;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.ChartEntry.Queries
{
    public class GetAllHeartRateChartEntriesByHeartRateIdQuery : IRequest<Result<List<HeartRateChartEntryDTO>>>
    {
        public int HeartRateChartId { get; set; }
    }

    public class GetAllHeartRateChartEntriesByHeartRateIdQueryHandler : IRequestHandler<GetAllHeartRateChartEntriesByHeartRateIdQuery, Result<List<HeartRateChartEntryDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllHeartRateChartEntriesByHeartRateIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<HeartRateChartEntryDTO>>> Handle(GetAllHeartRateChartEntriesByHeartRateIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<HeartRateChartEntryEntity, HeartRateChartEntryDTO>> expression = e => new HeartRateChartEntryDTO
                {
                    HeartRateChartEntryId = e.Id,
                    HeartRateChartId = e.HeartRateChartId,
                    HeartRateChartEntry = e.HeartRateChartEntry
                };

                var heartRateChartEntries = await _context.HeartRateChartEntries
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Where(x => x.HeartRateChartId == request.HeartRateChartId)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<HeartRateChartEntryDTO>>.SuccessAsync(heartRateChartEntries);
            }
            catch (Exception ex)
            {
                return await Result<List<HeartRateChartEntryDTO>>.FailAsync(ex.Message);
            }
        }
    }
}
