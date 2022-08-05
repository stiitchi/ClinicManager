using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Charts;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Charts.Queries
{
    public class GetBloodPressureChartByIdQuery : IRequest<Result<BloodPressureDTO>>
    {
        public int Id { get; set; }
    }

    public class GetBloodPressureChartByIdQueryHandler : IRequestHandler<GetBloodPressureChartByIdQuery, Result<BloodPressureDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetBloodPressureChartByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<BloodPressureDTO>> Handle(GetBloodPressureChartByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bloodPressure = await _context.BloodPressureCharts.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (bloodPressure == null)
                    throw new Exception("Unable to return Blood Pressure Chart");

                var dto = new BloodPressureDTO
                {
                    BloodPressureChartId        = bloodPressure.Id,
                    BloodPressureChartEntry     = bloodPressure.BloodPressureChartEntry,
                    Time                        = bloodPressure.Time,
                    PatientId                   = bloodPressure.PatientId
                };
                return await Result<BloodPressureDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<BloodPressureDTO>.FailAsync(ex.Message);
            }
        }
    }
}
