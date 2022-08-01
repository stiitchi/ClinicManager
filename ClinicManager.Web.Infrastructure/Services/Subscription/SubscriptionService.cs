using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.Subscription
{
    public class SubscriptionService : BaseService, ISubscriptionService
    {
        public SubscriptionService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        { }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.DeleteAsync(Routes.SubscriptionEndpoints.GetById(id));
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<SubscriptionDTO>>> GetAll()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.SubscriptionEndpoints.GetAllSubscriptions);
            return await response.ToResult<List<SubscriptionDTO>>(); throw new NotImplementedException();
        }

        public async Task<PaginatedResult<SubscriptionDTO>> GetAllCheckedSubscriptionsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.SubscriptionEndpoints.GetAllCheckedSubscriptionsTable(pageNumber, pageSize, searchString, orderBy));
            return await response.ToPaginatedResult<SubscriptionDTO>();
        }

        public async Task<PaginatedResult<SubscriptionDTO>> GetAllSubscriptionsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.SubscriptionEndpoints.GetAllSubscriptionsTable(pageNumber, pageSize, searchString, orderBy));
            return await response.ToPaginatedResult<SubscriptionDTO>();
        }

        public async Task<IResult<SubscriptionDTO>> GetById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.SubscriptionEndpoints.GetById(id));
            return await response.ToResult<SubscriptionDTO>();
        }

        public async Task<IResult<List<SubscriptionDTO>>> GetSubscriptionByChecked()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.SubscriptionEndpoints.GetSubscriptionByChecked);
            return await response.ToResult<List<SubscriptionDTO>>();
        }

        public async Task<IResult<int>> SaveAsync(SubscriptionDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.SubscriptionEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}
