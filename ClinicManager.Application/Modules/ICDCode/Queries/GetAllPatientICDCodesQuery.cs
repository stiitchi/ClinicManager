using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ICDCodeAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.ICDCode.Queries
{
   public class GetAllPatientICDCodesQuery : IRequest<Result<List<PatientICDCodeDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllPatientICDCodesQueryHandler : IRequestHandler<GetAllPatientICDCodesQuery, Result<List<PatientICDCodeDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPatientICDCodesQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<PatientICDCodeDTO>>> Handle(GetAllPatientICDCodesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PatientICDCodeEntity, PatientICDCodeDTO>> expression = e => new PatientICDCodeDTO
                {
                    PatientICDCodeId = e.Id,
                    ICDCodeId = e.IcdCodeId.ToString(),
                    PatientId = e.PatientId,
                    ICDCodeDescription = e.IcdDescription,
                    ICDCode = e.IcdCode
                };

                var icdCode = await _context.PatientICDCodes
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Where(x => x.PatientId == request.PatientId)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<PatientICDCodeDTO>>.SuccessAsync(icdCode);

            }
            catch (Exception ex)
            {
                return await Result<List<PatientICDCodeDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
