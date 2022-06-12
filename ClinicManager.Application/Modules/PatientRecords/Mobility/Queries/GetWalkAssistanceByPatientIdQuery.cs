using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Queries
{
     public class GetWalkAssistanceByPatientIdQuery : IRequest<Result<MobilityRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetWalkAssistanceByPatientIdQueryHandler : IRequestHandler<GetWalkAssistanceByPatientIdQuery, Result<MobilityRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetWalkAssistanceByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<MobilityRecordDTO>> Handle(GetWalkAssistanceByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var walkAssistanceEntry = await _context.WalkAssistanceTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.WalkWithAssistanceFrequency != 0,
                    cancellationToken);
                if (walkAssistanceEntry == null)
                    throw new Exception("Unable to return Mobility Record");

                var dto = new MobilityRecordDTO
                {
                    WalkWithAssistanceFrequency = walkAssistanceEntry.WalkWithAssistanceFrequency,
                    WalkWithAssistanceSignature = walkAssistanceEntry.WalkWithAssistanceSignature,
                    WalkWithAssistanceTime = walkAssistanceEntry.WalkWithAssistanceTime,
                    PatientId = walkAssistanceEntry.PatientId
                };
                return await Result<MobilityRecordDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<MobilityRecordDTO>.FailAsync(ex.Message);
            }
        }
    }
}
