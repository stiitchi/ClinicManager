using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.DTO_s.Auth;
using ClinicManager.Shared.Request;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<IResult<TokenResponse>> LoginAsync(TokenRequest request);
        Task<IResult<LogoutDTO>> LogoutAsync(LogoutDTO request);
        Task<IResult<bool>> GeneratePDF(SubscriptionDTO request);

    }
}
