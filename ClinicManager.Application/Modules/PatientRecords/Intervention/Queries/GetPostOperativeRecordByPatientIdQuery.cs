using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
    public class GetPostOperativeRecordByPatientIdQuery : IRequest<Result<InterventionRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetPostOperativeRecordByPatientIdQueryHandler : IRequestHandler<GetPostOperativeRecordByPatientIdQuery, Result<InterventionRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetPostOperativeRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<InterventionRecordDTO>> Handle(GetPostOperativeRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var postOperativeEntry = await _context.PostOperativeCareTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.PostOperativeCareFrequency != 0, 
                    cancellationToken);
                if (postOperativeEntry == null)
                    throw new Exception("Unable to return Post Operative Record");

                var dto = new InterventionRecordDTO
                {
                    PostOperativeCareFreq = postOperativeEntry.PostOperativeCareFrequency,
                    PostOperativeCareTime = postOperativeEntry.PostOperativeCareTime,
                    PostOperativeCareSignature = postOperativeEntry.PostOperativeCareSignature,
                    PatientId = postOperativeEntry.PatientId
                };
                return await Result<InterventionRecordDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<InterventionRecordDTO>.FailAsync(ex.Message);
            }
        }
    }
}
