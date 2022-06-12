using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Queries
{
      public class GetSelfCareRecordByPatientIdQuery : IRequest<Result<HygieneDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetSelfCareRecordByPatientIdQueryHandler : IRequestHandler<GetSelfCareRecordByPatientIdQuery, Result<HygieneDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetSelfCareRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<HygieneDTO>> Handle(GetSelfCareRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var selfCareRecord = await _context.SelfCareTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.SelfCareFrequency != 0, cancellationToken);
                if (selfCareRecord == null)
                    throw new Exception("Unable to return Self Care Record");

                var dto = new HygieneDTO
                {
                    SelfCareTime = selfCareRecord.SelfCareTime,
                    SelfCareFreq = selfCareRecord.SelfCareFrequency,
                    SelfCareSignature = selfCareRecord.SelfCareSignature,
                    PatientId = selfCareRecord.PatientId
                };
                return await Result<HygieneDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<HygieneDTO>.FailAsync(ex.Message);
            }
        }
    }
}

