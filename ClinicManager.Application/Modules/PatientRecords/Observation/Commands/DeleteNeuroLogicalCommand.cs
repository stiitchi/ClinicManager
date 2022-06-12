using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Commands
{
     public class DeleteNeuroLogicalCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteNeuroLogicalCommandHandler : IRequestHandler<DeleteNeuroLogicalCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteNeuroLogicalCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteNeuroLogicalCommand request, CancellationToken cancellationToken)
        {

            var neuroLogicalEntry = await _context.NeurologicalTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.NeurologicalTests.Remove(neuroLogicalEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(neuroLogicalEntry.Id);

        }
    }
}
