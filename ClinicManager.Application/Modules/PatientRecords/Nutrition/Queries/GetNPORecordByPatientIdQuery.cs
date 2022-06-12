using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Queries
{
   public class GetNPORecordByPatientIdQuery : IRequest<Result<NutritionRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetNPORecordByPatientIdQueryHandler : IRequestHandler<GetNPORecordByPatientIdQuery, Result<NutritionRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetNPORecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<NutritionRecordDTO>> Handle(GetNPORecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var npoRecordEntry = await _context.KeepNPOTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.KeepNPOFrequency != 0,
                    cancellationToken);
                if (npoRecordEntry == null)
                    throw new Exception("Unable to return NPO Record");

                var dto = new NutritionRecordDTO
                {
                    KeepNPOFrequency = npoRecordEntry.KeepNPOFrequency,
                    KeepNPOSignature = npoRecordEntry.KeepNPOSignature,
                    KeepNPOTime = npoRecordEntry.KeepNPOTime,
                    PatientId = npoRecordEntry.PatientId
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

