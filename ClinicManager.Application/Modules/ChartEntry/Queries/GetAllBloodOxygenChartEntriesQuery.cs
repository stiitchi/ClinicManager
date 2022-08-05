using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Shared.DTO_s.Charts.ChartEntry;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.ChartEntry.Queries
{
    public class GetAllBloodOxygenChartEntriesByBloodOxygenIdQuery : IRequest<Result<List<BloodOxygenChartEntryDTO>>>
    {
        public int BloodOxygenChartId { get; set; }
    }

    public class GetAllBloodOxygenChartEntriesByBloodOxygenIdQueryHandler : IRequestHandler<GetAllBloodOxygenChartEntriesByBloodOxygenIdQuery, Result<List<BloodOxygenChartEntryDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBloodOxygenChartEntriesByBloodOxygenIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<BloodOxygenChartEntryDTO>>> Handle(GetAllBloodOxygenChartEntriesByBloodOxygenIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BloodOxygenChartEntryEntity, BloodOxygenChartEntryDTO>> expression = e => new BloodOxygenChartEntryDTO
                {
                    BloodOxygenChartEntryId = e.Id,
                    BloodOxygenChartId      = e.BloodOxygenChartId,
                    BloodOxygenChartEntry   = e.BloodOxygenChartEntry
                };

                var bloodOxygenChartEntries = await _context.BloodOxygenChartEntries
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Where(x => x.BloodOxygenChartId == request.BloodOxygenChartId)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<BloodOxygenChartEntryDTO>>.SuccessAsync(bloodOxygenChartEntries);
            }
            catch (Exception ex)
            {
                return await Result<List<BloodOxygenChartEntryDTO>>.FailAsync(ex.Message);
            }
        }
    }
}
