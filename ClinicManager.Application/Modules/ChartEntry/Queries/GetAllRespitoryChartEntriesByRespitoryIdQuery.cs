using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Shared.DTO_s.Charts.ChartEntry;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.ChartEntry.Queries
{
    public class GetAllRespitoryChartEntriesByRespitoryIdQuery : IRequest<Result<List<RespitoryRateChartEntryDTO>>>
    {
        public int RespitoryRateChartId { get; set; }
    }

    public class GetAllRespitoryChartEntriesByRespitoryIdQueryHandler : IRequestHandler<GetAllRespitoryChartEntriesByRespitoryIdQuery, Result<List<RespitoryRateChartEntryDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllRespitoryChartEntriesByRespitoryIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<RespitoryRateChartEntryDTO>>> Handle(GetAllRespitoryChartEntriesByRespitoryIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<RespitoryRateChartEntryEntity, RespitoryRateChartEntryDTO>> expression = e => new RespitoryRateChartEntryDTO
                {
                    RespitoryRateChartEntryId   = e.Id,
                    RespitoryRateChartId        = e.RespitoryRateChartId,
                    RespitoryRateChartEntry     = e.RespitoryRateChartEntry
                };

                var respitoryRateChartEntries = await _context.RespitoryRateChartEntries
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Where(x => x.RespitoryRateChartId == request.RespitoryRateChartId)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<RespitoryRateChartEntryDTO>>.SuccessAsync(respitoryRateChartEntries);
            }
            catch (Exception ex)
            {
                return await Result<List<RespitoryRateChartEntryDTO>>.FailAsync(ex.Message);
            }
        }
    }
}
