using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
   public class GetUrineTestByPatientIdQuery : IRequest<Result<UrineTestDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetUrineTestByPatientIdQueryHandler : IRequestHandler<GetUrineTestByPatientIdQuery, Result<UrineTestDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetUrineTestByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<UrineTestDTO>> Handle(GetUrineTestByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var urineTestRecord = await _context.UrineTestTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId);
                if (urineTestRecord == null)
                    throw new Exception("Unable to return Urine Test");

                var dto = new UrineTestDTO
                {
                    UrineTestFrequency = urineTestRecord.UrineTestFrequency,
                    UrineTestSignature = urineTestRecord.UrineTestSignature,
                    UrineTestTime = urineTestRecord.UrineTestTime,
                    PatientId = urineTestRecord.PatientId
                };
                return await Result<UrineTestDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<UrineTestDTO>.FailAsync(ex.Message);
            }
        }
    }
}
