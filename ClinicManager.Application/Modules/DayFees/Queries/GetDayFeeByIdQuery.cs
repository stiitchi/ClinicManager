using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.DayFees.Queries
{
   public class GetDayFeeByIdQuery : IRequest<Result<DayFeesDTO>>
    {
        public int Id { get; set; }
    }

    public class GetDayFeeByIdQueryHandler : IRequestHandler<GetDayFeeByIdQuery, Result<DayFeesDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetDayFeeByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<DayFeesDTO>> Handle(GetDayFeeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dayFees = await _context.DayFees.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (dayFees == null)
                    throw new Exception("Unable to return Day Fee");
                var dto = new DayFeesDTO
                {
                    DayFeeCode      = dayFees.DayFeeCode,
                    Description     = dayFees.DayFeeDescription,
                    DateAdded       = dayFees.DateAdded
                };
                return await Result<DayFeesDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<DayFeesDTO>.FailAsync(ex.Message);
            }
        }
    }
}
