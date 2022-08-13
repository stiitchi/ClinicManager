using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Problems;
using ClinicManager.Shared.DTO_s.Patients;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientProblems.Queries
{
    public class GetAllPatientProblemsByPatientIdQuery : IRequest<Result<List<ProblemsDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllPatientProblemsByPatientIdQueryHandler : IRequestHandler<GetAllPatientProblemsByPatientIdQuery, Result<List<ProblemsDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPatientProblemsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<ProblemsDTO>>> Handle(GetAllPatientProblemsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PatientProblemsEntity, ProblemsDTO>> expression = e => new ProblemsDTO
                {
                    ProblemId   = e.Id,
                    Description = e.Description,
                    OnSetDate = e.OnSetDate,
                    PatientId   = e.PatientId
                };

                var problems = await _context.PatientProblems
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Where(x => x.PatientId== request.PatientId)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<ProblemsDTO>>.SuccessAsync(problems);

            }
            catch (Exception ex)
            {
                return await Result<List<ProblemsDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
