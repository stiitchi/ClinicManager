using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Safety;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Safety.Queries
{
     public class GetAllCotsideRecordsByPatientIdQuery : IRequest<Result<List<SafetyRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllCotsideRecordsByPatientIdQueryHandler : IRequestHandler<GetAllCotsideRecordsByPatientIdQuery, Result<List<SafetyRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCotsideRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<SafetyRecordDTO>>> Handle(GetAllCotsideRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<CotsideEntity, SafetyRecordDTO>> expression = e => new SafetyRecordDTO
                {
                    CotsidesFrequency = e.CotsidesFrequency,
                    CotsidesSignature = e.CotsidesSignature,
                    CotsidesTime = e.CotsidesTime,
                    PatientId = e.PatientId
                };

                var cotsideEntry = await _context.CotsideRecords
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.CotsidesFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<SafetyRecordDTO>>.SuccessAsync(cotsideEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<SafetyRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
