using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Queries
{ 
     public class GetSpecialRecordPatientIdQuery : IRequest<Result<NutritionRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetSpecialRecordPatientIdQueryHandler : IRequestHandler<GetSpecialRecordPatientIdQuery, Result<NutritionRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetSpecialRecordPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<NutritionRecordDTO>> Handle(GetSpecialRecordPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var specialEntry = await _context.SpecialTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.SpecialFrequency != 0,
                    cancellationToken);
                if (specialEntry == null)
                    throw new Exception("Unable to return Special Record");

                var dto = new NutritionRecordDTO
                {
                    SpecialTime = specialEntry.SpecialTime,
                    SpecialSignature = specialEntry.SpecialSignature,
                    SpecialFrequency = specialEntry.SpecialFrequency,
                    PatientId = specialEntry.PatientId
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
