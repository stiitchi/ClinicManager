using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Visits;
using ClinicManager.Shared.DTO_s.Patients;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Visits.Queries
{
    public class GetAllVisitsQuery : IRequest<Result<List<VisitDTO>>>
    {
    }

    public class GetAllVisitsQueryHandler : IRequestHandler<GetAllVisitsQuery, Result<List<VisitDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllVisitsQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<VisitDTO>>> Handle(GetAllVisitsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<VisitEntity, VisitDTO>> expression = e => new VisitDTO
                {
                    VisitId            = e.Id,
                    StartDate          = e.StartDate,
                    EndDate            = e.EndDate,
                    ProblemDescription = e.ProblemDescription,
                    Address            = e.Address,
                    City               = e.City,
                    PostalCode         = e.PostalCode,
                    Province           = e.Province,
                    PatientId          = e.PatientId
                };

                var visitations = await _context.PatientVisits
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<VisitDTO>>.SuccessAsync(visitations);

            }
            catch (Exception ex)
            {
                return await Result<List<VisitDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
