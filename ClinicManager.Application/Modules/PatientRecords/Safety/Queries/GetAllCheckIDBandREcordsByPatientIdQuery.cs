using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Safety;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Safety.Queries
{
    public class GetAllCheckIDBandREcordsByPatientIdQuery : IRequest<Result<List<SafetyRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllCheckIDBandRecordsByPatientIdQueryHandler : IRequestHandler<GetAllCheckIDBandREcordsByPatientIdQuery, Result<List<SafetyRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCheckIDBandRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<SafetyRecordDTO>>> Handle(GetAllCheckIDBandREcordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<CheckIdBandEntity, SafetyRecordDTO>> expression = e => new SafetyRecordDTO
                {
                    CheckIDBandsFrequency = e.CheckIDBandsFrequency,
                    CheckIDBandsSignature = e.CheckIDBandsSignature,
                    CheckIDBandsTime = e.CheckIDBandsTime,
                    PatientId = e.PatientId
                };

                var idBandsEntry = await _context.CheckIdBandTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.CheckIDBandsFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<SafetyRecordDTO>>.SuccessAsync(idBandsEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<SafetyRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
