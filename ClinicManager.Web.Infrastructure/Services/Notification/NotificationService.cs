using ClinicManager.Shared.DTO_s.Notifications;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.Notification
{
    public class NotificationService : BaseService, INotificationService
    {
        public NotificationService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        { }

        public async Task<IResult<int>> SaveAsync(NotificationDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.NotificationEndpoints.Save, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.DeleteAsync(Routes.NotificationEndpoints.GetById(id));
            return await response.ToResult<int>();
        }

        public async Task<IResult<NotificationDTO>> GetById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.NotificationEndpoints.GetById(id));
            return await response.ToResult<NotificationDTO>();
        }

        public async Task<PaginatedResult<NotificationDTO>> GetAllNotficationsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.NotificationEndpoints.GetAllNotficationsTable(pageNumber, pageSize, searchString, orderBy));
            return await response.ToPaginatedResult<NotificationDTO>();
        }

        public async Task<PaginatedResult<NotificationDTO>> GetAllNotificationsByTypeTable(int pageNumber, int pageSize, string searchString, string type, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.NotificationEndpoints.GetAllNotificationsByTypeTable(pageNumber, pageSize, searchString, type, orderBy));
            return await response.ToPaginatedResult<NotificationDTO>();
        }
    }
}
