using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Elimination.Queries
{
 public class GetContinentByPatientIdQuery : IRequest<Result<EliminationRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetContinentByPatientIdQueryHandler : IRequestHandler<GetContinentByPatientIdQuery, Result<EliminationRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetContinentByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<EliminationRecordDTO>> Handle(GetContinentByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var continentRecord = await _context.ContinentRecords.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.PatientId && c.ContinentFrequency != 0, cancellationToken);

                if (continentRecord == null)
                    throw new Exception("Unable to return Continent Record");

                var dto = new EliminationRecordDTO
                {
                ContinentTime = continentRecord.ContinentTime,
                ContinentSignature = continentRecord.ContinentSignature,
                ContinentFreq = continentRecord.ContinentFrequency,
                ContinentPatientId = continentRecord.PatientId
                };
                return await Result<EliminationRecordDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<EliminationRecordDTO>.FailAsync(ex.Message);
            }
        }
    }
}
