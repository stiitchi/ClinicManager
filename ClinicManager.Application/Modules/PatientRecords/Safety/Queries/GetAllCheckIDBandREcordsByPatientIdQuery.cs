using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Safety;
using ClinicManager.Shared.DTO_s.Records.Safety;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Safety.Queries
{
    public class GetAllCheckIDBandREcordsByPatientIdQuery : IRequest<Result<List<CheckIDBandDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllCheckIDBandRecordsByPatientIdQueryHandler : IRequestHandler<GetAllCheckIDBandREcordsByPatientIdQuery, Result<List<CheckIDBandDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCheckIDBandRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<CheckIDBandDTO>>> Handle(GetAllCheckIDBandREcordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<CheckIdBandEntity, CheckIDBandDTO>> expression = e => new CheckIDBandDTO
                {
                    CheckIDBandsId = e.Id,
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
                return await Result<List<CheckIDBandDTO>>.SuccessAsync(idBandsEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<CheckIDBandDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
