using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.DailyRecord.Queries
{
    public class GetDailyRecordByPatientIdQuery : IRequest<Result<DailyCareRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetDailyRecordByPatientIdQueryHandler : IRequestHandler<GetDailyRecordByPatientIdQuery, Result<DailyCareRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetDailyRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<DailyCareRecordDTO>> Handle(GetDailyRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dailyRecord = await _context.DailyCareRecords.AsNoTracking()
                    .IgnoreQueryFilters().FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);

                if (dailyRecord == null)
                    throw new Exception("Unable to return Daily Record");
                var dto = new DailyCareRecordDTO
                {
                    DailyCareRecordId   = dailyRecord.Id,
                    DateAdded           = dailyRecord.DateAdded,
                    TimeAdded           = dailyRecord.TimeAdded,
                    CareRecord          = dailyRecord.CareRecord,
                    PatientId           = dailyRecord.PatientId
                };
                return await Result<DailyCareRecordDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<DailyCareRecordDTO>.FailAsync(ex.Message);
            }
        }
    }
}
