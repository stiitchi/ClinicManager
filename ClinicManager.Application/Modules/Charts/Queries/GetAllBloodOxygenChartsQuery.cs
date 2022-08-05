using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate;
using ClinicManager.Shared.DTO_s.Charts;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Charts.Queries
{
    public class GetAllBloodOxygenChartsQuery : IRequest<Result<List<BloodOxygenDTO>>>
    {
    }

    public class GetAllBloodOxygenChartsQueryHandler : IRequestHandler<GetAllBloodOxygenChartsQuery, Result<List<BloodOxygenDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBloodOxygenChartsQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<BloodOxygenDTO>>> Handle(GetAllBloodOxygenChartsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BloodOxygenChartEntity, BloodOxygenDTO>> expression = e => new BloodOxygenDTO
                {
                    BloodOxygenChartId      = e.Id,
                    BloodOxygenChartEntry   = e.BloodOxygenChartEntry,
                    Time                    = e.Time,
                    PatientId               = e.PatientId
                };

                var bloodOxygenCharts = await _context.BloodOxygenCharts
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<BloodOxygenDTO>>.SuccessAsync(bloodOxygenCharts);

            }
            catch (Exception ex)
            {
                return await Result<List<BloodOxygenDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
