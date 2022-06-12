using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Queries
{
    public class GetAllSpecialRecordsByPatientIdQuery : IRequest<Result<List<NutritionRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllSpecialRecordsByPatientIdQueryHandler : IRequestHandler<GetAllSpecialRecordsByPatientIdQuery, Result<List<NutritionRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllSpecialRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<NutritionRecordDTO>>> Handle(GetAllSpecialRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<SpecialEntity, NutritionRecordDTO>> expression = e => new NutritionRecordDTO
                {
                    SpecialFrequency = e.SpecialFrequency,
                    SpecialSignature = e.SpecialSignature,
                    SpecialTime = e.SpecialTime,
                    PatientId = e.PatientId
                };

                var specialEntry = await _context.SpecialTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.SpecialFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<NutritionRecordDTO>>.SuccessAsync(specialEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<NutritionRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
