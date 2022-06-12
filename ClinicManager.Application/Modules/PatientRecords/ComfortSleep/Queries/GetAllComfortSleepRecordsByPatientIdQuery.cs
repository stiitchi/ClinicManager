using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.ComfortSleep;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.ComfortSleep.Queries
{
   public class GetAllComfortSleepRecordsByPatientIdQuery : IRequest<Result<List<ComfortSleepReportDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllComfortSleepRecordsByPatientIdQueryHandler : IRequestHandler<GetAllComfortSleepRecordsByPatientIdQuery, Result<List<ComfortSleepReportDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllComfortSleepRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<ComfortSleepReportDTO>>> Handle(GetAllComfortSleepRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var date = new DateTime();
            try
            {
                Expression<Func<NurseCarePlanComfortSleepEntity, ComfortSleepReportDTO>> expression = e => new ComfortSleepReportDTO
                {
                    ComfortSleepRecordId = e.Id,
                    Frequency = e.PainControlFrequency,
                    Signature = e.PainControlSignature,
                    PainControlDateTime = e.PainControlTime,
                    PatientId = e.PatientId
                };

                var progressReport = await _context.NurseCarePlanComfortSleepRecords
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<ComfortSleepReportDTO>>.SuccessAsync(progressReport);

            }
            catch (Exception ex)
            {
                return await Result<List<ComfortSleepReportDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
