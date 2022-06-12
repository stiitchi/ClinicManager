using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Commands
{
    public class DeleteOralOutputTestCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteOralOutputTestCommandHandler : IRequestHandler<DeleteOralOutputTestCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOralOutputTestCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteOralOutputTestCommand request, CancellationToken cancellationToken)
        {
            var oralTest = await _context.OralOutputTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.OralOutputTests.Remove(oralTest);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(oralTest.Id);
        }
    }
}