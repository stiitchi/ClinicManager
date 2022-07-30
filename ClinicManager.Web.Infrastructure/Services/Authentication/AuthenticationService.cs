using ClinicManager.Shared.Request;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.Authentication
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        public AuthenticationService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        {
        }

        public async Task<IResult<TokenResponse>> LoginAsync(TokenRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.AuthenticationEndpoints.Login, request);
            return await response.ToResult<TokenResponse>();
        }
    }
}
