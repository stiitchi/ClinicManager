using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Subscription.Queries
{
    public class GetSubscriptionByIdQuery : IRequest<Result<SubscriptionDTO>>
    {
        public int Id { get; set; }
    }

    public class GetSubscriptionByIdQueryHandler : IRequestHandler<GetSubscriptionByIdQuery, Result<SubscriptionDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetSubscriptionByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<SubscriptionDTO>> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var subscription = await _context.Subscriptions.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (subscription == null)
                    throw new Exception("Unable to return Subscription");
                var dto = new SubscriptionDTO
                {
                    Id             = subscription.Id,
                    Email          = subscription.Email,
                    MobileNo       = subscription.MobileNo,
                    ClinicName     = subscription.ClinicName,
                    repFirstName   = subscription.RepFirstName,
                    repLastName    = subscription.RepLastName,
                    PostalCode     = subscription.PostalCode,
                    City           = subscription.PostalCode,
                    Province       = subscription.PostalCode,
                    AmountOfNurses = subscription.AmountOfNurses,
                    StoragePlan    = subscription.StoragePlan,
                    PricePerNurse  = subscription.PricePerNurse,
                    Amount         = subscription.OverallTotal,
                    ClinicAddress  = subscription.ClinicAddress,
                    ReferenceNo    = subscription.ReferenceNumber

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
