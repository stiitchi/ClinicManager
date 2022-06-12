using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Commands
{
    public class DeleteIsolationCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteIsolationCommandHandler : IRequestHandler<DeleteIsolationCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteIsolationCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteIsolationCommand request, CancellationToken cancellationToken)
        {

            var isolationEntry = await _context.IsolationTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.IsolationTests.Remove(isolationEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(isolationEntry.Id);

        }
    }
}
