using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
    public class GetAllPostOperativeCareRecordsByPatientIdQuery : IRequest<Result<List<InterventionRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllPostOperativeCareRecordsByPatientIdQueryHandler : IRequestHandler<GetAllPostOperativeCareRecordsByPatientIdQuery, Result<List<InterventionRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPostOperativeCareRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<InterventionRecordDTO>>> Handle(GetAllPostOperativeCareRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PostOperativeCareEntity, InterventionRecordDTO>> expression = e => new InterventionRecordDTO
                {
                    PostOperativeCareFreq = e.PostOperativeCareFrequency,
                    PostOperativeCareTime = e.PostOperativeCareTime,
                    PostOperativeCareSignature = e.PostOperativeCareSignature,
                    PatientId = e.PatientId
                };

                var postOperativeCare = await _context.PostOperativeCareTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<InterventionRecordDTO>>.SuccessAsync(postOperativeCare);

            }
            catch (Exception ex)
            {
                return await Result<List<InterventionRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
