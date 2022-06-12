using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Commands
{
    public class DeleteBloodFrequencyCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteBloodFrequencyCommandHandler : IRequestHandler<DeleteBloodFrequencyCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBloodFrequencyCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteBloodFrequencyCommand request, CancellationToken cancellationToken)
        {

            var bloodFreqEntry = await _context.BloodTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.BloodTests.Remove(bloodFreqEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(bloodFreqEntry.Id);

        }
    }
}
