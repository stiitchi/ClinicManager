using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.DayFees.Commands
{
     public class EditDayFeeCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string DayFeeCode { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public class EditDayFeeCommandHandler : IRequestHandler<EditDayFeeCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public EditDayFeeCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(EditDayFeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dayFees = await _context.DayFees.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                if (dayFees == null)
                    throw new Exception("Day Fee doesn't exist");

                dayFees.Set(
                    request.DayFeeCode,
                    request.Description,
                    request.DateAdded
                    );


                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(dayFees.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
