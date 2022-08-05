using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.StoolChart.Queries
{
    public class GetStoolChartByPatientIdQuery : IRequest<Result<StoolChartDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetStoolChartByPatientIdQueryHandler : IRequestHandler<GetStoolChartByPatientIdQuery, Result<StoolChartDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetStoolChartByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<StoolChartDTO>> Handle(GetStoolChartByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var stoolChart = await _context.StoolChartTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);

                if (stoolChart == null)
                    throw new Exception("Unable to return Stool Chart");
                var dto = new StoolChartDTO
                {
                    Consistency         = stoolChart.Consistency,
                    BowelAmount         = stoolChart.BowelAmount,
                    StoolTime           = stoolChart.StoolChartTime,
                    StoolDate           = stoolChart.StoolChartDate,
                    Blood               = stoolChart.Blood,
                    MuscousAmount       = stoolChart.MucousAmount,
                    NormalBowelMovement = stoolChart.NormalBowelHabit,
                    PatientId           = stoolChart.PatientId
                };
                return await Result<StoolChartDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<StoolChartDTO>.FailAsync(ex.Message);
            }
        }
    }
}
