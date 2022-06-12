using ClinicManager.Shared.Constants;
using ClinicManager.Shared.DTO_s;

namespace ClinicManager.Web.Infrastructure.Services.State
{
    public class StateService : IStateService
    {
        //TODO Implement roles
        public event Action OnChange;
        private bool _isAdmin = false;
        private UserRolesDTO _activeUserRole = new();
        private UserDTO _user;
        private bool _isClient = false;

        public void SetClient()
        {
            _isClient = true;
        }

        public bool IsClient()
        {
            return _isClient;
        }

        public void SetUser(UserDTO user)
        {
            _user = user;
        }

        public UserDTO GetUser()
        {
            return _user;
        }

        public void SetActiveUserRole(UserRolesDTO userRole)
        {
            _activeUserRole = userRole;
            if (_activeUserRole.Role == Constants.RoleConstants.SYSTEM_ADMINISTRATOR)
            {
                _isAdmin = true;
            }
            else
            {
                _isAdmin = false;
            }
        }

        public UserRolesDTO GetActiveUserRole()
        {
            return _activeUserRole;
        }

        public void OnUserRoleUpdate()
        {
            if (_activeUserRole.Role == Constants.RoleConstants.SYSTEM_ADMINISTRATOR)
                _isAdmin = true;
            else
                _isAdmin = false;
            NotifyStateChanged();
        }

        public bool IsAdmin()
        {
            return _isAdmin;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
