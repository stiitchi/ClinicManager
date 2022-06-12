using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.DayFeesAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.DayFees.Queries
{
    public class GetAllDayFeesForLookupQuery : IRequest<Result<List<LookupDTO>>>
    {
    }

    public class GetAllDayFeesForLookupQueryHandler : IRequestHandler<GetAllDayFeesForLookupQuery, Result<List<LookupDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllDayFeesForLookupQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<LookupDTO>>> Handle(GetAllDayFeesForLookupQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<DayFeesEntity, LookupDTO>> expression = e => new LookupDTO
                {
                    Id = e.Id,
                    Name = e.DayFeeCode,
                    Prop1 = e.DayFeeDescription,
                    Prop2 = e.DateAdded.ToString()
                };

                var dayFee = await _context.DayFees
                    .AsNoTracking()
                    .Select(expression)
                    .ToListAsync(cancellationToken);
                return await Result<List<LookupDTO>>.SuccessAsync(dayFee);
            }
            catch (Exception ex)
            {
                return await Result<List<LookupDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}

