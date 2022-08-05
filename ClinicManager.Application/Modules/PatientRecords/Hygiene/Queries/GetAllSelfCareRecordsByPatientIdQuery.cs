using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene;
using ClinicManager.Shared.DTO_s.Records.Hygiene;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Queries
{
    public class GetAllSelfCareRecordsByPatientIdQuery : IRequest<Result<List<SelfCareDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllSelfCareRecordsByPatientIdQueryHandler : IRequestHandler<GetAllSelfCareRecordsByPatientIdQuery, Result<List<SelfCareDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllSelfCareRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<SelfCareDTO>>> Handle(GetAllSelfCareRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<SelfCareEntity, SelfCareDTO>> expression = e => new SelfCareDTO
                {
                    SelfCareId          = e.Id,
                    SelfCareTime        = e.SelfCareTime,
                    SelfCareFreq        = e.SelfCareFrequency,
                    SelfCareSignature   = e.SelfCareSignature,
                    PatientId           = e.PatientId
                };

                var selfCareReport = await _context.SelfCareTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<SelfCareDTO>>.SuccessAsync(selfCareReport);

            }
            catch (Exception ex)
            {
                return await Result<List<SelfCareDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
