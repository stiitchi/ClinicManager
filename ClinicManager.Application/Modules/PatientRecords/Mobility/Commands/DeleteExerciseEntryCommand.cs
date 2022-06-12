using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Commands
{
    public class DeleteExerciseEntryCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteExerciseEntryCommandHandler : IRequestHandler<DeleteExerciseEntryCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteExerciseEntryCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteExerciseEntryCommand request, CancellationToken cancellationToken)
        {

            var exerciseEntry = await _context.ExerciseTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.ExerciseTests.Remove(exerciseEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(exerciseEntry.Id);

        }
    }
}
