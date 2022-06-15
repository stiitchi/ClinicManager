using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Commands
{
    public class AddExerciseCommand : IRequest<Result<int>>
    {
        public DateTime ExercisesTime { get; set; }
        public int ExercisesFrequency { get; set; }
        public int ExercisesId { get; set; }
        public string ExercisesSignature { get; set; }
        public int PatientId { get; set; }


        public class AddExerciseCommandHandler : IRequestHandler<AddExerciseCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddExerciseCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddExerciseCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var exerciseEntry = await _context.ExerciseTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.Id == request.ExercisesId, cancellationToken);
                    if (exerciseEntry != null)
                        throw new Exception("Exercise Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var exerciseRecord = new ExerciseEntity(
                        request.ExercisesTime,
                        request.ExercisesFrequency,
                        request.ExercisesSignature,
                        patient
                        );

                    await _context.ExerciseTests.AddAsync(exerciseRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(exerciseRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
