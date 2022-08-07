using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Shared.DTO_s.Records.Intervention;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
    public class GetAllPostOperativeCareRecordsByPatientIdQuery : IRequest<Result<List<PostOperativeCareDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllPostOperativeCareRecordsByPatientIdQueryHandler : IRequestHandler<GetAllPostOperativeCareRecordsByPatientIdQuery, Result<List<PostOperativeCareDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPostOperativeCareRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<PostOperativeCareDTO>>> Handle(GetAllPostOperativeCareRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PostOperativeCareEntity, PostOperativeCareDTO>> expression = e => new PostOperativeCareDTO
                {
                    PostOperativeCareId        = e.Id,
                    PostOperativeCareFreq      = e.PostOperativeCareFrequency,
                    PostOperativeCareTime      = e.PostOperativeCareTime,
                    PostOperativeCareSignature = e.PostOperativeCareSignature,
                    PatientId                  = e.PatientId
                };

                var postOperativeCare = await _context.PostOperativeCareTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .OrderByDescending(x => x.PostOperativeCareTime)
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<PostOperativeCareDTO>>.SuccessAsync(postOperativeCare);

            }
            catch (Exception ex)
            {
                return await Result<List<PostOperativeCareDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
