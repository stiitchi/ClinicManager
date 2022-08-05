using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Elimination;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Elimination.Queries
{
  public class GetCathetherByPatientIdQuery : IRequest<Result<CathetherDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetCathetherByPatientIdQueryHandler : IRequestHandler<GetCathetherByPatientIdQuery, Result<CathetherDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetCathetherByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<CathetherDTO>> Handle(GetCathetherByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cathetherRecord = await _context.CathetherRecords.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.CathetherFrequency != 0, cancellationToken);

                if (cathetherRecord == null)
                    throw new Exception("Unable to return Cathether Record");
                var dto = new CathetherDTO
                {
                    CatheterId          = cathetherRecord.Id,
                    CatheterTime        = cathetherRecord.CathetherTime,
                    CatheterSignature   = cathetherRecord.CathetherSignature,
                    CatheterFreq        = cathetherRecord.CathetherFrequency,
                    PatientId           = cathetherRecord.PatientId
                };
                return await Result<CathetherDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<CathetherDTO>.FailAsync(ex.Message);
            }
        }
    }
}
