using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.DayFeesAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.DayFees.Commands
{
     public class AddDayFeeCommand : IRequest<Result<int>>
    {
        public string DayFeeCode { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public class AddDayFeeCommandHandler : IRequestHandler<AddDayFeeCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddDayFeeCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddDayFeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dayFees = await _context.DayFees.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.DayFeeCode == request.DayFeeCode, cancellationToken);
                if (dayFees != null)
                    throw new Exception("Day Fee already exists");

                var dayFeeCode = new DayFeesEntity(
                    request.DayFeeCode,
                    request.Description,
                    request.DateAdded
                    );

                await _context.DayFees.AddAsync(dayFeeCode, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(dayFeeCode.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
