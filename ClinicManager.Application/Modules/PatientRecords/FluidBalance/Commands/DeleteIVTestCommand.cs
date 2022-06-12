using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Commands
{
    public class DeleteIVTestCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteIVTestCommandHandler : IRequestHandler<DeleteIVTestCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteIVTestCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteIVTestCommand request, CancellationToken cancellationToken)
        {
            var ivTest = await _context.IVTestRecords.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.IVTestRecords.Remove(ivTest);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(ivTest.Id);
        }
    }
}
