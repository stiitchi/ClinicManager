using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Application.Extensions;
using ClinicManager.Domain.Entities.PatientAggregate.Visits;
using ClinicManager.Shared.DTO_s.Patients;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Visits.Queries
{
    public class GetAllVisitsTableQuery : IRequest<PaginatedResult<VisitDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; }

        public GetAllVisitsTableQuery(int pageNumber, int pageSize, string searchString, string orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }

    public class GetAllVisitsTableQueryHandler : IRequestHandler<GetAllVisitsTableQuery, PaginatedResult<VisitDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllVisitsTableQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedResult<VisitDTO>> Handle(GetAllVisitsTableQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<VisitEntity, VisitDTO>> expression = e => new VisitDTO
                {
                    VisitId            = e.Id,
                    ProblemDescription = e.ProblemDescription,
                    StartDate          = e.StartDate,
                    EndDate            = e.EndDate,
                    Address            = e.Address,
                    City               = e.City,
                    Province           = e.Province,
                    PostalCode         = e.PostalCode,
                    PatientId          = e.PatientId
                };

                IQueryable<VisitEntity> query = _context.PatientVisits;

                if (!string.IsNullOrEmpty(request.SearchString))
                    query = query.Where(o => o.ProblemDescription.ToString().Contains(request.SearchString) ||
                                             o.Address.ToString().Contains(request.SearchString));

                if (request.OrderBy?.Any() != true)
                {
                    var result = await query
                   .AsNoTracking()
                   .IgnoreQueryFilters()
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return result;
                }
                else
                {
                    var ordering = string.Join(",", request.OrderBy);
                    var result = await query
                    .AsNoTracking()
                    .IgnoreQueryFilters()
                    .OrderBy(ordering)
                    .Select(expression)
                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return await PaginatedResult<VisitDTO>.FailureAsync(new List<string> { ex.Message });
            }
        }
    }
}
