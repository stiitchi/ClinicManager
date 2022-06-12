using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Commands
{
    public class DeleteAssistInChairCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteAssistInChairCommandHandler : IRequestHandler<DeleteAssistInChairCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAssistInChairCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteAssistInChairCommand request, CancellationToken cancellationToken)
        {

            var chairAssistEntry = await _context.WalkChairTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.WalkChairTests.Remove(chairAssistEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(chairAssistEntry.Id);

        }
    }
}
