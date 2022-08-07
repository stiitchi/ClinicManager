using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using ClinicManager.Shared.DTO_s.Records.Oxygenation;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Queries
{
    public class GetAllPolyMaskByPatientIdQuery : IRequest<Result<List<PolyMaskDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllPolyMaskByPatientIdQueryHandler : IRequestHandler<GetAllPolyMaskByPatientIdQuery, Result<List<PolyMaskDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPolyMaskByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<PolyMaskDTO>>> Handle(GetAllPolyMaskByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PolyMaskEntity, PolyMaskDTO>> expression = e => new PolyMaskDTO
                {
                    PolyMaskId          = e.Id,
                    PolyMaskFrequency   = e.PolyMaskFrequency,
                    PolyMaskSignature   = e.PolyMaskSignature,
                    PolyMaskTime        = e.PolyMaskTime,
                    PatientId           = e.PatientId
                };

                var polyMaskEntry = await _context.PolyMaskTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .OrderByDescending(x => x.PolyMaskTime)
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<PolyMaskDTO>>.SuccessAsync(polyMaskEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<PolyMaskDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
