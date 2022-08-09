using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Subscription.Queries
{
    public class GetSubscriptionByCheckedQuery : IRequest<Result<SubscriptionDTO>>
    {
    }

    public class GetSubscriptionByCheckedQueryHandler : IRequestHandler<GetSubscriptionByCheckedQuery, Result<SubscriptionDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetSubscriptionByCheckedQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<SubscriptionDTO>> Handle(GetSubscriptionByCheckedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var subscription = await _context.Subscriptions.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.IsChecked == true, cancellationToken);

                if (subscription == null)
                    throw new Exception("Unable to return Subscription");
                var dto = new SubscriptionDTO
                {
                    Id              = subscription.Id,
                    Email           = subscription.Email,
                    MobileNo        = subscription.MobileNo,
                    ClinicName      = subscription.ClinicName,
                    repFirstName    = subscription.RepFirstName,
                    repLastName     = subscription.RepLastName,
                    PostalCode      = subscription.PostalCode,
                    City            = subscription.PostalCode,
                    Province        = subscription.PostalCode,
                    AmountOfNurses  = subscription.AmountOfNurses,
                    StoragePlan     = subscription.StoragePlan,
                    PricePerNurse   = subscription.PricePerNurse,
                    ReferenceNo     = subscription.ReferenceNumber,
                    ClinicAddress   = subscription.ClinicAddress,
                    Amount          = subscription.OverallTotal,
                    IsChecked       = subscription.IsChecked

                };
                return await Result<SubscriptionDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<SubscriptionDTO>.FailAsync(ex.Message);
            }
        }
    }
}
