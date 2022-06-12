using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Commands
{
    public class DeleteOralInputTestCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteOralInputTestCommandHandler : IRequestHandler<DeleteOralInputTestCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOralInputTestCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteOralInputTestCommand request, CancellationToken cancellationToken)
        {
            var oralTest = await _context.OralIntakeTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.OralIntakeTests.Remove(oralTest);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(oralTest.Id);
        }
    }
}
