using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using ClinicManager.Shared.DTO_s.Records.Mobility;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Queries
{
     public class GetAllExerciseByPatientIdQuery : IRequest<Result<List<ExerciseDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllExerciseByPatientIdQueryHandler : IRequestHandler<GetAllExerciseByPatientIdQuery, Result<List<ExerciseDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllExerciseByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<ExerciseDTO>>> Handle(GetAllExerciseByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<ExerciseEntity, ExerciseDTO>> expression = e => new ExerciseDTO
                {
                    ExercisesId         = e.Id,
                    ExercisesTime       = e.ExercisesTime,
                    ExercisesFrequency  = e.ExercisesFrequency,
                    ExercisesSignature  = e.ExercisesSignature,
                    PatientId           = e.PatientId
                };

                var excerciseEntry = await _context.ExerciseTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.ExercisesFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<ExerciseDTO>>.SuccessAsync(excerciseEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<ExerciseDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
