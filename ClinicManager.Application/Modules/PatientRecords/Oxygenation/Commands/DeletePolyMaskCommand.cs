using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Commands
{
    public class DeletePolyMaskCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePolyMaskCommandHandler : IRequestHandler<DeletePolyMaskCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeletePolyMaskCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeletePolyMaskCommand request, CancellationToken cancellationToken)
        {
            var polyMaskTimeEntry = await _context.PolyMaskTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.PolyMaskTests.Remove(polyMaskTimeEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(polyMaskTimeEntry.Id);
        }
    }
}
