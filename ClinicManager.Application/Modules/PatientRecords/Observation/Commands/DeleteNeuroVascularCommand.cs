using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Commands
{
    public class DeleteNeuroVascularCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteNeuroVascularCommandHandler : IRequestHandler<DeleteNeuroVascularCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteNeuroVascularCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteNeuroVascularCommand request, CancellationToken cancellationToken)
        {

            var neuroVascularEntry = await _context.NeurovascularTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.NeurovascularTests.Remove(neuroVascularEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(neuroVascularEntry.Id);

        }
    }
}
