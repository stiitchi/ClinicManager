using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.DTO_s.Auth;
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

        public async Task<IResult<LogoutDTO>> LogoutAsync(LogoutDTO request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.AuthenticationEndpoints.Logout, request);
            return await response.ToResult<LogoutDTO>();
        }


        public async Task<IResult<bool>> GeneratePDF(SubscriptionDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.AuthenticationEndpoints.GeneratePDF, request);

            return await response.ToResult<bool>();
        }
    }
}
