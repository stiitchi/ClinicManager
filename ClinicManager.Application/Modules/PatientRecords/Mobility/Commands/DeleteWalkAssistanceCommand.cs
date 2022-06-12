using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Commands
{
    public class DeleteWalkAssistanceCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteWalkAssistanceCommandHandler : IRequestHandler<DeleteWalkAssistanceCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteWalkAssistanceCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteWalkAssistanceCommand request, CancellationToken cancellationToken)
        {

            var walkAssistanceEntry = await _context.WalkAssistanceTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.WalkAssistanceTests.Remove(walkAssistanceEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(walkAssistanceEntry.Id);

        }
    }
}
