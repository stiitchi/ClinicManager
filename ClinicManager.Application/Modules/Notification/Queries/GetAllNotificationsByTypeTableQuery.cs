using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Application.Extensions;
using ClinicManager.Domain.Entities.NotificationAggregate;
using ClinicManager.Shared.DTO_s.Notifications;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Notification.Queries
{
  public class GetAllNotificationsByTypeTableQuery : IRequest<PaginatedResult<NotificationDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Type { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; }

        public GetAllNotificationsByTypeTableQuery(int pageNumber, int pageSize, string searchString, string type, string orderBy)
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

    public class GetAllNotificationsByTypeTableQueryHandler : IRequestHandler<GetAllNotificationsByTypeTableQuery, PaginatedResult<NotificationDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllNotificationsByTypeTableQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedResult<NotificationDTO>> Handle(GetAllNotificationsByTypeTableQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<NotificationEntity, NotificationDTO>> expression = e => new NotificationDTO
                {
                    Id              = e.Id,
                    UserId          = e.UserId,
                    Description     = e.Description,
                    CreatedOn       = e.CreatedOn,
                    SeenOn          = e.SeenOn
                };

                IQueryable<NotificationEntity> query = _context.Notifications;

                if (!string.IsNullOrEmpty(request.SearchString))
                    query = query.Where(o => o.Description.ToString().Contains(request.SearchString));

                if (request.OrderBy?.Any() != true)
                {
                    var result = await query
                   .AsNoTracking()
                   .IgnoreQueryFilters()
                   .Where(x => x.Type == request.Type)
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
                    .Where(x => x.Type == request.Type)
                    .OrderBy(ordering)
                    .Select(expression)
                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return await PaginatedResult<NotificationDTO>.FailureAsync(new List<string> { ex.Message });
            }
        }
    }
}
