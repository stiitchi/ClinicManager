using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Mobility;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Queries
{ 
    public class GetExerciseRecordByPatientIdQuery : IRequest<Result<ExerciseDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetExerciseRecordByPatientIdQueryHandler : IRequestHandler<GetExerciseRecordByPatientIdQuery, Result<ExerciseDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetExerciseRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<ExerciseDTO>> Handle(GetExerciseRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var exerciseEntry = await _context.ExerciseTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.ExercisesFrequency != 0,
                    cancellationToken);
                if (exerciseEntry == null)
                    throw new Exception("Unable to return Exercise Record");

                var dto = new ExerciseDTO
                {
                    ExercisesFrequency = exerciseEntry.ExercisesFrequency,
                    ExercisesSignature = exerciseEntry.ExercisesSignature,
                    ExercisesTime = exerciseEntry.ExercisesTime,
                    PatientId = exerciseEntry.PatientId
                };
                return await Result<ExerciseDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<ExerciseDTO>.FailAsync(ex.Message);
            }
        }
    }
}
