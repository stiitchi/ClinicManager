using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Charts;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Charts.Queries
{
    public class GetRespitoryRateChartByIdQuery : IRequest<Result<RespitoryChartDTO>>
    {
        public int Id { get; set; }
    }

    public class GetRespitoryRateChartByIdQueryHandler : IRequestHandler<GetRespitoryRateChartByIdQuery, Result<RespitoryChartDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetRespitoryRateChartByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<RespitoryChartDTO>> Handle(GetRespitoryRateChartByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var respitoryChartEntry = await _context.RespitoryRateCharts.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (respitoryChartEntry == null)
                    throw new Exception("Unable to return Respitory Chart");

                var dto = new RespitoryChartDTO
                {
                    RespitoryChartId = respitoryChartEntry.Id,
                    RespitoryChartEntry = respitoryChartEntry.RespitoryChartEntry,
                    Time = respitoryChartEntry.Time,
                    PatientId = respitoryChartEntry.PatientId
                };
                return await Result<RespitoryChartDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<RespitoryChartDTO>.FailAsync(ex.Message);
            }
        }
    }
}
