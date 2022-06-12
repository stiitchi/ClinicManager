using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Commands
{
    public class DeleteBloodGlucoseCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteBloodGlucoseCommandHandler : IRequestHandler<DeleteBloodGlucoseCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBloodGlucoseCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteBloodGlucoseCommand request, CancellationToken cancellationToken)
        {

            var bloodGlucoseEntry = await _context.BloodGlucoseTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.BloodGlucoseTests.Remove(bloodGlucoseEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(bloodGlucoseEntry.Id);

        }
    }
}
