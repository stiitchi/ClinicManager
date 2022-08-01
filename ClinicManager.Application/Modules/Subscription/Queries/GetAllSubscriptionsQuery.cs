using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.SubscriptionAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Subscription.Queries
{

    public class GetAllSubscriptionsQuery : IRequest<Result<List<SubscriptionDTO>>>
    {
    }

    public class GetAllSubscriptionsQueryHandler : IRequestHandler<GetAllSubscriptionsQuery, Result<List<SubscriptionDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllSubscriptionsQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<SubscriptionDTO>>> Handle(GetAllSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<SubscriptionEntity, SubscriptionDTO>> expression = e => new SubscriptionDTO
                {
                    Id              = e.Id,
                    Email           = e.Email,
                    MobileNo        = e.MobileNo,
                    ClinicName      = e.ClinicName,
                    repFirstName    = e.RepFirstName,
                    repLastName     = e.RepLastName,
                    ClinicAddress   = e.ClinicAddress,
                    PostalCode      = e.PostalCode,
                    City            = e.City,
                    Province        = e.Province,
                    AmountOfNurses  = e.AmountOfNurses,
                    StoragePlan     = e.StoragePlan,
                    PricePerNurse   = e.PricePerNurse,
                    Amount          = e.OverallTotal,
                    ReferenceNo     = e.ReferenceNumber
                };

                var subscription = await _context.Subscriptions
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<SubscriptionDTO>>.SuccessAsync(subscription);

            }
            catch (Exception ex)
            {
                return await Result<List<SubscriptionDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
