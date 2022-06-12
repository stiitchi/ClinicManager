using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Queries
{
    public class GetAllNPORecordByPatientIdQuery : IRequest<Result<List<NutritionRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllNPORecordByPatientIdQueryHandler : IRequestHandler<GetAllNPORecordByPatientIdQuery, Result<List<NutritionRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllNPORecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<NutritionRecordDTO>>> Handle(GetAllNPORecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<KeepNPOEntity, NutritionRecordDTO>> expression = e => new NutritionRecordDTO
                {
                    KeepNPOTime = e.KeepNPOTime,
                    KeepNPOFrequency = e.KeepNPOFrequency,
                    KeepNPOSignature = e.KeepNPOSignature,
                    PatientId = e.PatientId
                };

                var npoEntry = await _context.KeepNPOTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.KeepNPOFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<NutritionRecordDTO>>.SuccessAsync(npoEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<NutritionRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
