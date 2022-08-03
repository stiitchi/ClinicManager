using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Notification.Commands
{
    public class DeleteNotificationCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteRoomCommandHandler : IRequestHandler<DeleteNotificationCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRoomCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var notif = await _context.Notifications.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.Notifications.Remove(notif);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(notif.Id);
        }
    }
}

