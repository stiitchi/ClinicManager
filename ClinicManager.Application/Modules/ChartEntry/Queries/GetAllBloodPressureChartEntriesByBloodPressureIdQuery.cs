using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Shared.DTO_s.Charts.ChartEntry;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.ChartEntry.Queries
{

    public class GetAllBloodPressureChartEntriesByBloodPressureIdQuery : IRequest<Result<List<BloodPressureChartEntryDTO>>>
    {
        public int BloodPressureChartId { get; set; }
    }

    public class GetAllBloodPressureChartEntriesByBloodPressureIdQueryHandler : IRequestHandler<GetAllBloodPressureChartEntriesByBloodPressureIdQuery, Result<List<BloodPressureChartEntryDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBloodPressureChartEntriesByBloodPressureIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<BloodPressureChartEntryDTO>>> Handle(GetAllBloodPressureChartEntriesByBloodPressureIdQuery request, CancellationToken cancellationToken)
        {
            try
            {     
                Expression<Func<BloodPressureChartEntryEntity, BloodPressureChartEntryDTO>> expression = e => new BloodPressureChartEntryDTO
                {
                    BloodPressureChartEntryId = e.Id,
                    BloodPressureChartId = e.BloodPressureChartId,
                    BloodPressureChartEntry = e.BloodPressureChartEntry
                };

                var bloodPressureChartEntries = await _context.BloodPressureChartEntries
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Where(x => x.BloodPressureChartId == request.BloodPressureChartId)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<BloodPressureChartEntryDTO>>.SuccessAsync(bloodPressureChartEntries);
            }
            catch (Exception ex)
            {
                return await Result<List<BloodPressureChartEntryDTO>>.FailAsync(ex.Message);
            }
        }
    }
}
