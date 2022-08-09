using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Application.Helpers;
using ClinicManager.Application.Modules.Azure.Commands;
using ClinicManager.Domain.Entities.SubscriptionAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Subscription.Commands
{
    public class AddSubscriptionCommand : IRequest<Result<int>>
    {
        public int SubscriptionId { get; set; }
        public string ReferenceNumber { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string ClinicName { get; set; }
        public string repFirstName { get; set; }
        public string repLastName { get; set; }
        public string ClinicAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int AmountOfNurses { get; set; }
        public int Amount { get; set; }
        public string StoragePlan { get; set; }
        public int PricePerNurse { get; set; }
    }

    public class AddSubscriptionCommandHandler : IRequestHandler<AddSubscriptionCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public AddSubscriptionCommandHandler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Result<int>> Handle(AddSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var subscriptions = await _context.Subscriptions.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.SubscriptionId, cancellationToken);
                if (subscriptions != null)
                    throw new Exception("Subscription already exists");

                var reference = ReferenceGenerator.Generate();

                var subscription = new SubscriptionEntity(
                    reference,
                    request.Email,
                    request.MobileNo,
                    request.ClinicName,
                    request.repFirstName,
                    request.repLastName,
                    request.ClinicAddress,
                    request.PostalCode,
                    request.City,
                    request.Province,
                    request.AmountOfNurses,
                    request.StoragePlan,
                    request.PricePerNurse
                    );


                SubscriptionDTO subscriptionDTO = new SubscriptionDTO()
                {
                    Email          = request.Email,
                    AmountOfNurses = request.AmountOfNurses,
                    City           = request.City,
                    ClinicAddress  = request.ClinicAddress,
                    ClinicName     = request.ClinicName,
                    MobileNo       = request.MobileNo,
                    PostalCode     = request.PostalCode,
                    PricePerNurse  = request.PricePerNurse,
                    Province       = request.Province,
                    ReferenceNo    = subscription.ReferenceNumber,
                    repFirstName   = request.repFirstName,
                    repLastName    = request.repLastName,
                    StoragePlan    = request.StoragePlan,
                    Amount         = request.Amount
                };

                var result = await _mediator.Send(new AddPDFToBlobStorageCommand(subscriptionDTO));

                subscription.SetPDFPath($"reference-invoice_{subscription.ReferenceNumber}.pdf");
                await _context.Subscriptions.AddAsync(subscription, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(subscription.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
