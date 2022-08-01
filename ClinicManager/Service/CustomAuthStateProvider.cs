using Blazored.LocalStorage;
using ClinicManager.Shared.Constants;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.DTO_s.Auth;
using ClinicManager.Web.Infrastructure.Services.State;
using Microsoft.AspNetCore.Components.Authorization;
using ClinicManager.Web.Infrastructure.Services.Authentication;
using System.Security.Claims;

namespace ClinicManager.Service
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private ILocalStorageService _localStorage;
        private IStateService _stateService;
        private IAuthenticationService _authenticationService;

        public CustomAuthStateProvider(ILocalStorageService localStorageService, IStateService stateService, IAuthenticationService authenticationService)
        {
            _localStorage          = localStorageService;
            _stateService          = stateService;
            _authenticationService = authenticationService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var email           = await _localStorage.GetItemAsync<string>(Constants.Local.Email);
            var userId          = await _localStorage.GetItemAsync<string>(Constants.Local.UserId);
            var firstName       = await _localStorage.GetItemAsync<string>(Constants.Local.FirstName);
            var lastName        = await _localStorage.GetItemAsync<string>(Constants.Local.LastName);
            var roleId          = await _localStorage.GetItemAsync<string>(Constants.Local.ActiveRoleId);
            var role            = await _localStorage.GetItemAsync<string>(Constants.Local.ActiveRole);
            var roleDisplayName = await _localStorage.GetItemAsync<string>(Constants.Local.ActiveRoleDisplayName);
            var profilePicture  = await _localStorage.GetItemAsync<string>(Constants.Local.ProfilePicture);
            var identity        = new ClaimsIdentity("apiauth_type");

            if (string.IsNullOrEmpty(email))
                identity = new ClaimsIdentity();
            else
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, firstName),
                new Claim(ClaimTypes.GivenName, lastName),
            };

                identity.AddClaims(claims);
            }

            _stateService.SetActiveUserRole(new UserRolesDTO
            {
                Role = role,
                RoleID = Convert.ToInt32(roleId),
                RoleDisplayName = roleDisplayName
            });

            _stateService.SetUser(new UserDTO
            {
                Id = Convert.ToInt32(userId),
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                ImageUrl = profilePicture
            });
            _stateService.OnUserRoleUpdate();
            var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(user));
        }

        public async Task SetActiveUserRoleAsync(UserRolesDTO userRole)
        {
            await _localStorage.SetItemAsync(Constants.Local.ActiveRoleId, userRole.RoleID);
            await _localStorage.SetItemAsync(Constants.Local.ActiveRole, userRole.Role);
            await _localStorage.SetItemAsync(Constants.Local.ActiveRoleDisplayName, userRole.RoleDisplayName);
        }

        public async Task MarkUserAsAuthAsync(UserDTO userdto)
        {
            var userId = userdto.Id.ToString();
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, userdto.Email),
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, userdto.FirstName),
                new Claim(ClaimTypes.GivenName, userdto.LastName)
            }, "apiauth_type");
            var user = new ClaimsPrincipal(identity);
            await _localStorage.SetItemAsync(Constants.Local.Email, userdto.Email);
            await _localStorage.SetItemAsync(Constants.Local.UserId, userId);
            await _localStorage.SetItemAsync(Constants.Local.FirstName, userdto.FirstName);
            await _localStorage.SetItemAsync(Constants.Local.LastName, userdto.LastName);
            await _localStorage.SetItemAsync(Constants.Local.ProfilePicture, userdto.ImageUrl);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task MarkUserAsLoggedOutAsync()
        {

            //LogoutDTO logout = new();

            //var userId = await _localStorage.GetItemAsStringAsync(Constants.Local.UserId, null);

            //var response = _authenticationService.LogoutAsync(logout);

            await _localStorage.RemoveItemAsync(Constants.Local.Email);
            await _localStorage.RemoveItemAsync(Constants.Local.UserId);
            await _localStorage.RemoveItemAsync(Constants.Local.FirstName);
            await _localStorage.RemoveItemAsync(Constants.Local.LastName);
            await _localStorage.RemoveItemAsync(Constants.Local.ProfilePicture);
            await _localStorage.RemoveItemAsync(Constants.Local.ActiveRoleId);
            await _localStorage.RemoveItemAsync(Constants.Local.ActiveRole);
            await _localStorage.RemoveItemAsync(Constants.Local.ActiveRoleDisplayName);

            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
