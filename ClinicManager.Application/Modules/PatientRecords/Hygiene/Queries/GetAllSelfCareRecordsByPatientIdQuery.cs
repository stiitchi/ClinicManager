using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Queries
{
    public class GetAllSelfCareRecordsByPatientIdQuery : IRequest<Result<List<HygieneDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllSelfCareRecordsByPatientIdQueryHandler : IRequestHandler<GetAllSelfCareRecordsByPatientIdQuery, Result<List<HygieneDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllSelfCareRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<HygieneDTO>>> Handle(GetAllSelfCareRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<SelfCareEntity, HygieneDTO>> expression = e => new HygieneDTO
                {
                    SelfCareTime = e.SelfCareTime,
                    SelfCareFreq = e.SelfCareFrequency,
                    SelfCareSignature = e.SelfCareSignature,
                    PatientId = e.PatientId
                };

                var selfCareReport = await _context.SelfCareTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.SelfCareFreq != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<HygieneDTO>>.SuccessAsync(selfCareReport);

            }
            catch (Exception ex)
            {
                return await Result<List<HygieneDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
