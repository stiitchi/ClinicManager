using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.DailyCare;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.DailyRecord.Queries
{
    public class GetAllDailyRecordsByPatientIdQuery : IRequest<Result<List<DailyCareRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllDailyRecordsByPatientIdQueryHandler : IRequestHandler<GetAllDailyRecordsByPatientIdQuery, Result<List<DailyCareRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllDailyRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<DailyCareRecordDTO>>> Handle(GetAllDailyRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<DailyCareRecordEntity, DailyCareRecordDTO>> expression = e => new DailyCareRecordDTO
                {
                    DailyCareRecordId   = e.Id,
                    DateAdded           = e.DateAdded,
                    TimeAdded           = e.TimeAdded,
                    CareRecord          = e.CareRecord,
                    PatientId           = e.PatientId
                };

                var dailyRecords = await _context.DailyCareRecords
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .OrderByDescending(x => x.DateAdded)
                        .Where(d => d.PatientId == request.PatientId)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<DailyCareRecordDTO>>.SuccessAsync(dailyRecords);

            }
            catch (Exception ex)
            {
                return await Result<List<DailyCareRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
