using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Elimination.Queries
{
  public class GetCathetherByPatientIdQuery : IRequest<Result<EliminationRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetCathetherByPatientIdQueryHandler : IRequestHandler<GetCathetherByPatientIdQuery, Result<EliminationRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetCathetherByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<EliminationRecordDTO>> Handle(GetCathetherByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cathetherRecord = await _context.CathetherRecords.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.CathetherFrequency != 0, cancellationToken);

                if (cathetherRecord == null)
                    throw new Exception("Unable to return Cathether Record");
                var dto = new EliminationRecordDTO
                {
                    CatheterTime = cathetherRecord.CathetherTime,
                    CatheterSignature = cathetherRecord.CathetherSignature,
                    CatheterFreq = cathetherRecord.CathetherFrequency,
                    CatheterPatientId = cathetherRecord.PatientId
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
