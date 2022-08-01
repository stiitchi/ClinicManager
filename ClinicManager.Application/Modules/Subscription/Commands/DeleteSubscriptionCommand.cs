using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Subscription.Commands
{
    public class DeleteSubscriptionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSubscriptionCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _context.Subscriptions.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(subscription.Id);
        }
    }
}
