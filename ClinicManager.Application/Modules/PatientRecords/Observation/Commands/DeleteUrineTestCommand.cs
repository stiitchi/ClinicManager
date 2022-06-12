using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Commands
{
    public class DeleteUrineTestCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteUrineTestCommandHandler : IRequestHandler<DeleteUrineTestCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteUrineTestCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteUrineTestCommand request, CancellationToken cancellationToken)
        {

            var urineTestEntry = await _context.UrineTestTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.UrineTestTests.Remove(urineTestEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(urineTestEntry.Id);

        }
    }
}
