using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Elimination;
using ClinicManager.Shared.DTO_s.Records.Elimination;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Elimination.Queries
{
  public class GetAllContinentsByPatientIdQuery : IRequest<Result<List<ContinentDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllContinentsByPatientIdQueryHandler : IRequestHandler<GetAllContinentsByPatientIdQuery, Result<List<ContinentDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllContinentsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<ContinentDTO>>> Handle(GetAllContinentsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<ContinentEntity, ContinentDTO>> expression = e => new ContinentDTO
                {
                    ContinentId         = e.Id,
                    ContinentTime       = e.ContinentTime,
                    ContinentFreq       = e.ContinentFrequency,
                    ContinentSignature  = e.ContinentSignature,
                    PatientId           = e.PatientId
                };

                var continentReport = await _context.ContinentRecords
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<ContinentDTO>>.SuccessAsync(continentReport);

            }
            catch (Exception ex)
            {
                return await Result<List<ContinentDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
