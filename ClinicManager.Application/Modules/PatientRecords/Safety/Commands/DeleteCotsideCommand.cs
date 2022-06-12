using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Safety.Commands
{
    public class DeleteCotsideCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCotsideCommandHandler : IRequestHandler<DeleteCotsideCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCotsideCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteCotsideCommand request, CancellationToken cancellationToken)
        {

            var cotsideEntry = await _context.CotsideRecords.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.CotsideRecords.Remove(cotsideEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(cotsideEntry.Id);

        }
    }
}
