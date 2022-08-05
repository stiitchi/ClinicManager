using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Shared.DTO_s.Records.Intervention;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Queries
{
     public class GetAllWoundCareRecordsByPatientIdQuery : IRequest<Result<List<WoundCareDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllWoundCareRecordsByPatientIdQueryHandler : IRequestHandler<GetAllWoundCareRecordsByPatientIdQuery, Result<List<WoundCareDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllWoundCareRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<WoundCareDTO>>> Handle(GetAllWoundCareRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<WoundCareEntity, WoundCareDTO>> expression = e => new WoundCareDTO
                {
                    WoundCareId         = e.Id,
                    WoundCareFreq       = e.WoundCareFrequency,
                    WoundCareTime       = e.WoundCareTime,
                    WoundCareSignature  = e.WoundCareSignature,
                    PatientId           = e.PatientId
                };

                var woundCareRecords = await _context.WoundCareTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<WoundCareDTO>>.SuccessAsync(woundCareRecords);

            }
            catch (Exception ex)
            {
                return await Result<List<WoundCareDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
