using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Charts;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Charts.Queries
{
    public class GetBloodOxygenChartsByIdQuery : IRequest<Result<BloodOxygenDTO>>
    {
        public int Id { get; set; }
    }

    public class GetBloodOxygenChartsByIdQueryHandler : IRequestHandler<GetBloodOxygenChartsByIdQuery, Result<BloodOxygenDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetBloodOxygenChartsByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<BloodOxygenDTO>> Handle(GetBloodOxygenChartsByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bloodOxy = await _context.BloodOxygenCharts.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (bloodOxy == null)
                    throw new Exception("Unable to return Blood Oxygen Chart");

                var dto = new BloodOxygenDTO
                {
                    BloodOxygenChartId      = bloodOxy.Id,
                    BloodOxygenChartEntry   = bloodOxy.BloodOxygenChartEntry,
                    Time                    = bloodOxy.Time,
                    PatientId               = bloodOxy.PatientId
                };
                return await Result<BloodOxygenDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<BloodOxygenDTO>.FailAsync(ex.Message);
            }
        }
    }
}
