using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Queries
{
    public class GetAllPolyMaskByPatientIdQuery : IRequest<Result<List<OxygenationRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllPolyMaskByPatientIdQueryHandler : IRequestHandler<GetAllPolyMaskByPatientIdQuery, Result<List<OxygenationRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPolyMaskByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<OxygenationRecordDTO>>> Handle(GetAllPolyMaskByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PolyMaskEntity, OxygenationRecordDTO>> expression = e => new OxygenationRecordDTO
                {
                    PolyMaskFrequency = e.PolyMaskFrequency,
                    PolyMaskSignature = e.PolyMaskSignature,
                    PolyMaskTime = e.PolyMaskTime,
                    PatientId = e.PatientId
                };

                var polyMaskEntry = await _context.PolyMaskTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.PolyMaskFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<OxygenationRecordDTO>>.SuccessAsync(polyMaskEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<OxygenationRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
