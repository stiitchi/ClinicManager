using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Nutrition;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Queries
{ 
     public class GetSpecialRecordPatientIdQuery : IRequest<Result<SpecialDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetSpecialRecordPatientIdQueryHandler : IRequestHandler<GetSpecialRecordPatientIdQuery, Result<SpecialDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetSpecialRecordPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<SpecialDTO>> Handle(GetSpecialRecordPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var specialEntry = await _context.SpecialTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId,
                    cancellationToken);
                if (specialEntry == null)
                    throw new Exception("Unable to return Special Record");

                var dto = new SpecialDTO
                {
                    SpecialId = specialEntry.Id,
                    SpecialTime = specialEntry.SpecialTime,
                    SpecialSignature = specialEntry.SpecialSignature,
                    SpecialFrequency = specialEntry.SpecialFrequency,
                    PatientId = specialEntry.PatientId
                };
                return await Result<SpecialDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<SpecialDTO>.FailAsync(ex.Message);
            }
        }
    }
}
