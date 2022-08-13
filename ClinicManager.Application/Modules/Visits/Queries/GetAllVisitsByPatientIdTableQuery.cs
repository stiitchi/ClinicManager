using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Visits;
using ClinicManager.Shared.DTO_s.Patients;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using ClinicManager.Application.Extensions;

namespace ClinicManager.Application.Modules.Visits.Queries
{
    public class GetAllVisitsByPatientIdTableQuery : IRequest<PaginatedResult<VisitDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PatientId { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; }

        public GetAllVisitsByPatientIdTableQuery(int pageNumber, int pageSize, string searchString, int patientId, string orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            PatientId = patientId;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }

    public class GetAllVisitsByPatientIdTableQueryHandler : IRequestHandler<GetAllVisitsByPatientIdTableQuery, PaginatedResult<VisitDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllVisitsByPatientIdTableQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedResult<VisitDTO>> Handle(GetAllVisitsByPatientIdTableQuery request, CancellationToken cancellationToken)
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
                   .Where(x => x.PatientId == request.PatientId)
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
                    .Where(x => x.PatientId == request.PatientId)
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
