using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Application.Extensions;
using ClinicManager.Domain.Entities.SubscriptionAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Subscription.Queries
{
    public class GetAllCheckedSubscriptionsTableQuery : IRequest<PaginatedResult<SubscriptionDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; }

        public GetAllCheckedSubscriptionsTableQuery(int pageNumber, int pageSize, string searchString, string orderBy)
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

    public class GetAllCheckedSubscriptionsTableQueryHandler : IRequestHandler<GetAllCheckedSubscriptionsTableQuery, PaginatedResult<SubscriptionDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCheckedSubscriptionsTableQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedResult<SubscriptionDTO>> Handle(GetAllCheckedSubscriptionsTableQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<SubscriptionEntity, SubscriptionDTO>> expression = e => new SubscriptionDTO
                {
                    Id              = e.Id,
                    Email           = e.Email,
                    MobileNo        = e.MobileNo,
                    ClinicAddress   = e.ClinicAddress,
                    ClinicName      = e.ClinicName,
                    repFirstName    = e.RepFirstName,
                    repLastName     = e.RepLastName,
                    PostalCode      = e.PostalCode,
                    City            = e.City,
                    Province        = e.Province,
                    AmountOfNurses  = e.AmountOfNurses,
                    StoragePlan     = e.StoragePlan,
                    PricePerNurse   = e.PricePerNurse,
                    ReferenceNo     = e.ReferenceNumber,
                    Amount          = e.OverallTotal
                };

                IQueryable<SubscriptionEntity> query = _context.Subscriptions;

                if (!string.IsNullOrEmpty(request.SearchString))
                    query = query.Where(o => o.ClinicName.ToString().Contains(request.SearchString) ||
                                             o.RepFirstName.ToString().Contains(request.SearchString) ||
                                             o.RepLastName.ToString().Contains(request.SearchString) ||
                                             o.Email.ToString().Contains(request.SearchString) ||
                                             o.MobileNo.ToString().Contains(request.SearchString) ||
                                             o.ClinicAddress.ToString().Contains(request.SearchString)
                                             );

                if (request.OrderBy?.Any() != true)
                {
                    var result = await query
                   .AsNoTracking()
                   .IgnoreQueryFilters()
                   .Where(x => x.IsChecked)
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
                    .Where(x => x.IsChecked)
                    .Select(expression)
                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return await PaginatedResult<SubscriptionDTO>.FailureAsync(new List<string> { ex.Message });
            }
        }
    }
}
