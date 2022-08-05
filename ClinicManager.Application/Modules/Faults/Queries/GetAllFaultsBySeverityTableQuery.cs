using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Application.Extensions;
using ClinicManager.Domain.Entities.FaultAggregate;
using ClinicManager.Shared.DTO_s.Faults;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Faults.Queries
{
    public class GetAllFaultsBySeverityTableQuery : IRequest<PaginatedResult<FaultsDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string Severity { get; set; }
        public string[] OrderBy { get; set; }

        public GetAllFaultsBySeverityTableQuery(int pageNumber, int pageSize, string searchString, string severity, string orderBy)
        {
            PageNumber   = pageNumber;
            PageSize     = pageSize;
            SearchString = searchString;
            Severity     = severity;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }

    public class GetAllFaultsBySeverityTableQueryHandler : IRequestHandler<GetAllFaultsBySeverityTableQuery, PaginatedResult<FaultsDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllFaultsBySeverityTableQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedResult<FaultsDTO>> Handle(GetAllFaultsBySeverityTableQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<FaultEntity, FaultsDTO>> expression = e => new FaultsDTO
                {
                    Id          = e.Id,
                    UserId      = e.UserId,
                    Description = e.Description,
                    CreatedOn   = e.CreatedOn,
                    SeenOn      = e.SeenOn
                };

                IQueryable<FaultEntity> query = _context.Faults;

                if (!string.IsNullOrEmpty(request.SearchString))
                    query = query.Where(o => o.Description.ToString().Contains(request.SearchString));

                if (request.OrderBy?.Any() != true)
                {
                    var result = await query
                   .AsNoTracking()
                   .IgnoreQueryFilters()
                   .Where(x => x.Serverity == request.Severity)
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
                    .Where(x => x.Serverity == request.Severity)
                    .OrderBy(ordering)
                    .Select(expression)
                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return await PaginatedResult<FaultsDTO>.FailureAsync(new List<string> { ex.Message });
            }
        }
    }
}
