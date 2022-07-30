using ClinicManager.Shared.Request;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<IResult<TokenResponse>> LoginAsync(TokenRequest request);
    }
}
