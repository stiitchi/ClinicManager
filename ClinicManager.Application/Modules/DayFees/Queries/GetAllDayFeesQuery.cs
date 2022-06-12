using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.DayFeesAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.DayFees.Queries
{
    public class GetAllDayFeesQuery : IRequest<Result<List<DayFeesDTO>>>
    {
    }

    public class GetAllDayFeesQueryHandler : IRequestHandler<GetAllDayFeesQuery, Result<List<DayFeesDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllDayFeesQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<DayFeesDTO>>> Handle(GetAllDayFeesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<DayFeesEntity, DayFeesDTO>> expression = e => new DayFeesDTO
                {
                    DayFeeID = e.Id,
                    DayFeeCode = e.DayFeeCode,
                    DateAdded = e.DateAdded,
                    Description = e.DayFeeDescription
                };

                var dayFeeCode = await _context.DayFees
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<DayFeesDTO>>.SuccessAsync(dayFeeCode);

            }
            catch (Exception ex)
            {
                return await Result<List<DayFeesDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
