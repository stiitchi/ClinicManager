using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Queries
{
    public class GetFullWardDietByPatientIdQuery : IRequest<Result<NutritionRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetFullWardDietByPatientIdQueryHandler : IRequestHandler<GetFullWardDietByPatientIdQuery, Result<NutritionRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetFullWardDietByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<NutritionRecordDTO>> Handle(GetFullWardDietByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var fullWardEntry = await _context.WardDietTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.FullWardDietFrequency != 0,
                    cancellationToken);
                if (fullWardEntry == null)
                    throw new Exception("Unable to return Full Ward Diet Record");

                var dto = new NutritionRecordDTO
                {
                    FullWardDietFrequency = fullWardEntry.FullWardDietFrequency,
                    FullWardDietSignature = fullWardEntry.FullWardDietSignature,
                    FullWardDietTime = fullWardEntry.FullWardDietTime,
                    PatientId = fullWardEntry.PatientId
                };
                return await Result<NutritionRecordDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<NutritionRecordDTO>.FailAsync(ex.Message);
            }
        }
    }
}
