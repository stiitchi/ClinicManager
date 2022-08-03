using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.NotificationAggregate;
using ClinicManager.Shared.Constants;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Notification.Commands
{
    public class AddNotificationCommand : IRequest<Result<int>>
    {

        public int Id { get; set; }

        public NotificationType NotificationType { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime SeenOn { get; set; }

        public int UserId { get; set; }

    }

    public class AddNotificationCommandHandler : IRequestHandler<AddNotificationCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddNotificationCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var notifications = await _context.Notifications.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                if (notifications != null)
                    throw new Exception("Notification already exists");

                var user = await _context.Users.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.UserId, cancellationToken);
                if (user == null)
                    throw new Exception("User doesn't exist");

                var notification = new NotificationEntity(
                    request.NotificationType.ToString(),
                    request.Description,
                    request.CreatedOn,
                    user
                    );


                await _context.Notifications.AddAsync(notification, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(notification.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
