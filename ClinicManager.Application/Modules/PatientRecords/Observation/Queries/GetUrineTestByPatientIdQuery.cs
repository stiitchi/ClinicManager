using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
   public class GetUrineTestByPatientIdQuery : IRequest<Result<ObservationRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetUrineTestByPatientIdQueryHandler : IRequestHandler<GetUrineTestByPatientIdQuery, Result<ObservationRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetUrineTestByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<ObservationRecordDTO>> Handle(GetUrineTestByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var urineTestRecord = await _context.UrineTestTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.UrineTestFrequency != 0,
                    cancellationToken);
                if (urineTestRecord == null)
                    throw new Exception("Unable to return Urine Test");

                var dto = new ObservationRecordDTO
                {
                    UrineTestFrequency = urineTestRecord.UrineTestFrequency,
                    UrineTestSignature = urineTestRecord.UrineTestSignature,
                    UrineTestTime = urineTestRecord.UrineTestTime,
                    PatientId = urineTestRecord.PatientId
                };
                return await Result<ObservationRecordDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<ObservationRecordDTO>.FailAsync(ex.Message);
            }
        }
    }
}
