using ClinicManager.Web.Infrastructure.Services.State;

namespace ClinicManager.Web.Infrastructure.Services
{
    public abstract class BaseService
    {
        public readonly HttpClient _httpClient;
        public readonly IStateService _stateService;

        public BaseService(HttpClient httpClient, IStateService stateService)
        {
            _stateService = stateService;
            _httpClient = httpClient;
        }

        public async Task ConfigureHeaders()
        {
            //_httpClient.DefaultRequestHeaders.Remove(Constants.HeaderConstants.RoleId);
            //_httpClient.DefaultRequestHeaders.Remove(Constants.HeaderConstants.UserId);
            //Implement when JWT authentication is fixed
            //if (request.Headers.Authorization?.Scheme != "Bearer")
            //{
            //    var savedToken = await this.localStorage.GetItemAsync<string>(StorageConstants.Local.AuthToken);

            //    if (!string.IsNullOrWhiteSpace(savedToken))
            //    {
            //        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
            //    }
            //}

            //if (_stateService.GetActiveUserRole().RoleID > 0)
            //{
            //    _httpClient.DefaultRequestHeaders.Add(Constants.HeaderConstants.RoleId, _stateService.GetActiveUserRole().RoleID.ToString());
            //    _httpClient.DefaultRequestHeaders.Add(Constants.HeaderConstants.UserId, _stateService.GetActiveUserRole().UserID.ToString());
            //}
        }
    }
}
