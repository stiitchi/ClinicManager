using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Elimination;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Elimination.Queries
{
  public class GetAllContinentsByPatientIdQuery : IRequest<Result<List<EliminationRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllContinentsByPatientIdQueryHandler : IRequestHandler<GetAllContinentsByPatientIdQuery, Result<List<EliminationRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllContinentsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<EliminationRecordDTO>>> Handle(GetAllContinentsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<ContinentEntity, EliminationRecordDTO>> expression = e => new EliminationRecordDTO
                {
                    EliminationRecordId = e.Id,
                    ContinentTime = e.ContinentTime,
                    ContinentFreq = e.ContinentFrequency,
                    ContinentSignature = e.ContinentSignature,
                    ContinentPatientId = e.PatientId
                };

                var continentReport = await _context.ContinentRecords
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.ContinentPatientId == request.PatientId && r.ContinentFreq != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<EliminationRecordDTO>>.SuccessAsync(continentReport);

            }
            catch (Exception ex)
            {
                return await Result<List<EliminationRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
