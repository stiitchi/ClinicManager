using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Elimination;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Elimination.Queries
{
 public class GetContinentByPatientIdQuery : IRequest<Result<ContinentDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetContinentByPatientIdQueryHandler : IRequestHandler<GetContinentByPatientIdQuery, Result<ContinentDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetContinentByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<ContinentDTO>> Handle(GetContinentByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var continentRecord = await _context.ContinentRecords.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.PatientId && c.ContinentFrequency != 0, cancellationToken);

                if (continentRecord == null)
                    throw new Exception("Unable to return Continent Record");

                var dto = new ContinentDTO
                {
                ContinentId         = continentRecord.Id,
                ContinentTime       = continentRecord.ContinentTime,
                ContinentSignature  = continentRecord.ContinentSignature,
                ContinentFreq       = continentRecord.ContinentFrequency,
                PatientId           = continentRecord.PatientId
                };
                return await Result<ContinentDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<ContinentDTO>.FailAsync(ex.Message);
            }
        }
    }
}
