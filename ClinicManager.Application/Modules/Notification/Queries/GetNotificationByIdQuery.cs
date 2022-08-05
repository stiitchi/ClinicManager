using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Notifications;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Notification.Queries
{
    public class GetNotificationByIdQuery : IRequest<Result<NotificationDTO>>
    {
        public int Id { get; set; }
    }

    public class GetNotificationByIdQueryHandler : IRequestHandler<GetNotificationByIdQuery, Result<NotificationDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetNotificationByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<NotificationDTO>> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var notification = await _context.Notifications.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (notification == null)
                    throw new Exception("Unable to return Notification");

                var dto = new NotificationDTO
                {
                    Id              = notification.Id,
                    Description     = notification.Description,
                    CreatedOn       = notification.CreatedOn,
                    SeenOn          = notification.SeenOn,
                    UserId          = notification.UserId
                };
                return await Result<NotificationDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<NotificationDTO>.FailAsync(ex.Message);
            }
        }
    }
}
