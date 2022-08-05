using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Hygiene;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Queries
{
      public class GetSelfCareRecordByPatientIdQuery : IRequest<Result<SelfCareDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetSelfCareRecordByPatientIdQueryHandler : IRequestHandler<GetSelfCareRecordByPatientIdQuery, Result<SelfCareDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetSelfCareRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<SelfCareDTO>> Handle(GetSelfCareRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var selfCareRecord = await _context.SelfCareTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.SelfCareFrequency != 0, cancellationToken);
                if (selfCareRecord == null)
                    throw new Exception("Unable to return Self Care Record");

                var dto = new SelfCareDTO
                {
                    SelfCareId          = selfCareRecord.Id,
                    SelfCareTime        = selfCareRecord.SelfCareTime,
                    SelfCareFreq        = selfCareRecord.SelfCareFrequency,
                    SelfCareSignature   = selfCareRecord.SelfCareSignature,
                    PatientId           = selfCareRecord.PatientId
                };
                return await Result<SelfCareDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<SelfCareDTO>.FailAsync(ex.Message);
            }
        }
    }
}

