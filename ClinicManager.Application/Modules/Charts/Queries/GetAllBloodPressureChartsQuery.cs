using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate;
using ClinicManager.Shared.DTO_s.Charts;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Charts.Queries
{
    public class GetAllBloodPressureChartsQuery : IRequest<Result<List<BloodPressureDTO>>>
    {
    }

    public class GetAllBloodPressureChartsQueryHandler : IRequestHandler<GetAllBloodPressureChartsQuery, Result<List<BloodPressureDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBloodPressureChartsQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<BloodPressureDTO>>> Handle(GetAllBloodPressureChartsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BloodPressureChartEntity, BloodPressureDTO>> expression = e => new BloodPressureDTO
                {
                    BloodPressureChartId = e.Id,
                    BloodPressureChartEntry = e.BloodPressureChartEntry,
                    Time = e.Time,
                    PatientId = e.PatientId
                };

                var bloodPressureEntry = await _context.BloodPressureCharts
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<BloodPressureDTO>>.SuccessAsync(bloodPressureEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<BloodPressureDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
