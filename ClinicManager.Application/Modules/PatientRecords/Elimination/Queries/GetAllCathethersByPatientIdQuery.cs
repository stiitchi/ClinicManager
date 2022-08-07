using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Elimination;
using ClinicManager.Shared.DTO_s.Records.Elimination;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Elimination.Queries
{ 
    public class GetAllCathethersByPatientIdQuery : IRequest<Result<List<CathetherDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllCathethersByPatientIdQueryHandler : IRequestHandler<GetAllCathethersByPatientIdQuery, Result<List<CathetherDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCathethersByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<CathetherDTO>>> Handle(GetAllCathethersByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<CathetherEntity, CathetherDTO>> expression = e => new CathetherDTO
                {
                    CatheterId          = e.Id,
                    CatheterTime        = e.CathetherTime,
                    CatheterFreq        = e.CathetherFrequency,
                    CatheterSignature   = e.CathetherSignature,
                    PatientId           = e.PatientId
                };

                var cathetherReport = await _context.CathetherRecords
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .OrderByDescending(x => x.CathetherTime)
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<CathetherDTO>>.SuccessAsync(cathetherReport);

            }
            catch (Exception ex)
            {
                return await Result<List<CathetherDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
