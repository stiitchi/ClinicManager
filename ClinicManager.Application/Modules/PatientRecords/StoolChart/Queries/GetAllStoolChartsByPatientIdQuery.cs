using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.StoolCharts;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.StoolChart.Queries
{
    public class GetAllStoolChartsByPatientIdQuery : IRequest<Result<List<StoolChartDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllStoolChartsByPatientIdQueryHandler : IRequestHandler<GetAllStoolChartsByPatientIdQuery, Result<List<StoolChartDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllStoolChartsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<StoolChartDTO>>> Handle(GetAllStoolChartsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<StoolChartEntity, StoolChartDTO>> expression = e => new StoolChartDTO
                {
                    Blood = e.Blood,
                    BowelAmount = e.BowelAmount,
                    Consistency = e.Consistency,
                    MuscousAmount = e.MucousAmount,
                    NormalBowelMovement = e.NormalBowelHabit,
                    StoolDate = e.StoolChartDate,
                    StoolTime = e.StoolChartTime,   
                    PatientId = e.PatientId
                };

                var stoolChart = await _context.StoolChartTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.BowelAmount != "")
                        .ToListAsync(cancellationToken);
                return await Result<List<StoolChartDTO>>.SuccessAsync(stoolChart);

            }
            catch (Exception ex)
            {
                return await Result<List<StoolChartDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
