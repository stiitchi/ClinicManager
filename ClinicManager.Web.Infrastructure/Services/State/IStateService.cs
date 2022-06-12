using ClinicManager.Shared.DTO_s;

namespace ClinicManager.Web.Infrastructure.Services.State
{
    public interface IStateService
    {
        public event Action OnChange;

        void OnUserRoleUpdate();

        bool IsAdmin();

        void SetActiveUserRole(UserRolesDTO userRole);

        UserRolesDTO GetActiveUserRole();

        void SetUser(UserDTO user);

        UserDTO GetUser();

        void SetClient();

        bool IsClient();
    }
}
