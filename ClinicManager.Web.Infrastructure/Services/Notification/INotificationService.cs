using ClinicManager.Shared.DTO_s.Notifications;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.Notification
{
    public interface INotificationService
    {
        Task<IResult<NotificationDTO>> GetById(int id);

        Task<IResult<int>> SaveAsync(NotificationDTO request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<PaginatedResult<NotificationDTO>> GetAllNotficationsTable(int pageNumber, int pageSize, string searchString, string[] orderBy);

        Task<PaginatedResult<NotificationDTO>> GetAllNotificationsByTypeTable(int pageNumber, int pageSize, string searchString, string type, string[] orderBy);
    }
}
