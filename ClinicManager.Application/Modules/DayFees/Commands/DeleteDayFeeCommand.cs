using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.DayFees.Commands
{
     public class DeleteDayFeeCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDayFeeCommandHandler : IRequestHandler<DeleteDayFeeCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteDayFeeCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteDayFeeCommand request, CancellationToken cancellationToken)
        {
            var dayFees = await _context.DayFees.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.DayFees.Remove(dayFees);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(dayFees.Id);
        }
    }
}
