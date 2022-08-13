using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Problems;
using ClinicManager.Shared.DTO_s.Patients;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using ClinicManager.Application.Extensions;

namespace ClinicManager.Application.Modules.PatientProblems.Queries
{
    public class GetAllPatientProblemsByPatientIdTableQuery : IRequest<PaginatedResult<ProblemsDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PatientId { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; }

        public GetAllPatientProblemsByPatientIdTableQuery(int pageNumber, int pageSize, string searchString, int patientId, string orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            PatientId = patientId;
            SearchString = searchString;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }

    public class GetAllPatientProblemsByPatientIdTableQueryHandler : IRequestHandler<GetAllPatientProblemsByPatientIdTableQuery, PaginatedResult<ProblemsDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPatientProblemsByPatientIdTableQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedResult<ProblemsDTO>> Handle(GetAllPatientProblemsByPatientIdTableQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PatientProblemsEntity, ProblemsDTO>> expression = e => new ProblemsDTO
                {
                    ProblemId   = e.Id,
                    Description = e.Description,
                    OnSetDate   = e.OnSetDate,
                    PatientId   = e.PatientId
                };

                IQueryable<PatientProblemsEntity> query = _context.PatientProblems;

                if (!string.IsNullOrEmpty(request.SearchString))
                    query = query.Where(o => o.Description.ToString().Contains(request.SearchString));

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
                return await PaginatedResult<ProblemsDTO>.FailureAsync(new List<string> { ex.Message });
            }
        }
    }
}
