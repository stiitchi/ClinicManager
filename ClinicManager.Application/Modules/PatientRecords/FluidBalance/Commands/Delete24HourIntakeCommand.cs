using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Commands
{
    public class Delete24HourIntakeCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class Delete24HourIntakeCommandHandler : IRequestHandler<Delete24HourIntakeCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public Delete24HourIntakeCommandHandler()
        {
        }

        public Delete24HourIntakeCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(Delete24HourIntakeCommand request, CancellationToken cancellationToken)
        {
            var fluidBalanceRecord = await _context.Previous24HourIntakeTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.Previous24HourIntakeTests.Remove(fluidBalanceRecord);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(fluidBalanceRecord.Id);
        }
    }
}
