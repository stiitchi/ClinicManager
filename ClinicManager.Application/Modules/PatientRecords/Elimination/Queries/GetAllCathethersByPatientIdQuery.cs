using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Elimination;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Elimination.Queries
{ 
    public class GetAllCathethersByPatientIdQuery : IRequest<Result<List<EliminationRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllCathethersByPatientIdQueryHandler : IRequestHandler<GetAllCathethersByPatientIdQuery, Result<List<EliminationRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCathethersByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<EliminationRecordDTO>>> Handle(GetAllCathethersByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<CathetherEntity, EliminationRecordDTO>> expression = e => new EliminationRecordDTO
                {
                    EliminationRecordId = e.Id,
                    CatheterTime = e.CathetherTime,
                    CatheterFreq = e.CathetherFrequency,
                    CatheterSignature = e.CathetherSignature,
                    CatheterPatientId = e.PatientId
                };

                var cathetherReport = await _context.CathetherRecords
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.CatheterPatientId == request.PatientId && r.CatheterFreq != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<EliminationRecordDTO>>.SuccessAsync(cathetherReport);

            }
            catch (Exception ex)
            {
                return await Result<List<EliminationRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
