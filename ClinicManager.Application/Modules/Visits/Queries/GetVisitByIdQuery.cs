using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Patients;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Visits.Queries
{
    public class GetVisitByIdQuery : IRequest<Result<VisitDTO>>
    {
        public int Id { get; set; }
    }

    public class GetVisitByIdQueryHandler : IRequestHandler<GetVisitByIdQuery, Result<VisitDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetVisitByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<VisitDTO>> Handle(GetVisitByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var visit = await _context.PatientVisits.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (visit == null)
                    throw new Exception("Unable to return Visitation");

                var dto = new VisitDTO
                {
                    VisitId            = visit.Id,
                    StartDate          = visit.StartDate,
                    EndDate            = visit.EndDate,
                    ProblemDescription = visit.ProblemDescription,
                    Address            = visit.Address,
                    City               = visit.City,
                    Province           = visit.Province,
                    PostalCode         = visit.PostalCode,
                    PatientId          = visit.PatientId
                };
                return await Result<VisitDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<VisitDTO>.FailAsync(ex.Message);
            }
        }
    }
}
