using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Patients;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientProblems.Queries
{
    public class GetPatientProblemByIdQuery : IRequest<Result<ProblemsDTO>>
    {
        public int Id { get; set; }
    }

    public class GetPatientProblemByIdQueryHandler : IRequestHandler<GetPatientProblemByIdQuery, Result<ProblemsDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetPatientProblemByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<ProblemsDTO>> Handle(GetPatientProblemByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var problems = await _context.PatientProblems.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (problems == null)
                    throw new Exception("Unable to return Patient Problem");

                var dto = new ProblemsDTO
                {
                    ProblemId   = problems.Id,
                    Description = problems.Description,
                    OnSetDate   = problems.OnSetDate,
                    PatientId   = problems.PatientId
                };
                return await Result<ProblemsDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<ProblemsDTO>.FailAsync(ex.Message);
            }
        }
    }
}
