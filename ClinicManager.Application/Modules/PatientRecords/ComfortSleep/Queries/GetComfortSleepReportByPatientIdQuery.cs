using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.ComfortSleep.Queries
{
    public class GetComfortSleepReportByPatientIdQuery : IRequest<Result<ComfortSleepReportDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetComfortSleepReportByPatientIdQueryHandler : IRequestHandler<GetComfortSleepReportByPatientIdQuery, Result<ComfortSleepReportDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetComfortSleepReportByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<ComfortSleepReportDTO>> Handle(GetComfortSleepReportByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var date = new DateTime();

            try
            {
                var comfortSleepReport = await _context.NurseCarePlanComfortSleepRecords.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);

                if (comfortSleepReport == null)
                    throw new Exception("Unable to return Comfort Sleep Report");
                var dto = new ComfortSleepReportDTO
                {
                    PainControlDateTime     = comfortSleepReport.PainControlTime,
                    PatientId               = comfortSleepReport.PatientId,
                    Signature               = comfortSleepReport.PainControlSignature,
                    Frequency               = comfortSleepReport.PainControlFrequency,
                    ComfortSleepRecordId    = comfortSleepReport.Id
                };
                return await Result<ComfortSleepReportDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<ComfortSleepReportDTO>.FailAsync(ex.Message);
            }
        }
    }
}
