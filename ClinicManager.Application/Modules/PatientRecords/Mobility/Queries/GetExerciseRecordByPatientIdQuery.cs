using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Queries
{ 
    public class GetExerciseRecordByPatientIdQuery : IRequest<Result<MobilityRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetExerciseRecordByPatientIdQueryHandler : IRequestHandler<GetExerciseRecordByPatientIdQuery, Result<MobilityRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetExerciseRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<MobilityRecordDTO>> Handle(GetExerciseRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var exerciseEntry = await _context.ExerciseTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.ExercisesFrequency != 0,
                    cancellationToken);
                if (exerciseEntry == null)
                    throw new Exception("Unable to return Exercise Record");

                var dto = new MobilityRecordDTO
                {
                    ExercisesFrequency = exerciseEntry.ExercisesFrequency,
                    ExercisesSignature = exerciseEntry.ExercisesSignature,
                    ExercisesTime = exerciseEntry.ExercisesTime,
                    PatientId = exerciseEntry.PatientId
                };
                return await Result<MobilityRecordDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<MobilityRecordDTO>.FailAsync(ex.Message);
            }
        }
    }
}
