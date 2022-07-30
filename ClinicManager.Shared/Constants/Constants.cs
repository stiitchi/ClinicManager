

namespace ClinicManager.Shared.Constants
{
    public class Constants
    {
        public static class Local
        {
            public static string Email = "email";
            public static string UserId = "userId";
            public static string FirstName = "firstName";
            public static string LastName = "lastName";
            public static string ProfilePicture = "ProfilePicture";
            public static string ActiveRoleId = "active_role_id";
            public static string ActiveRole = "active_role";
            public static string ActiveRoleDisplayName = "active_role_display_name";
        }

        public static class HeaderConstants
        {
            public static string RoleId = "RoleId";
            public static string UserId = "UserId";
        }

        public class RoleConstants
        {
            public static string SYSTEM_ADMINISTRATOR = "SYSTEM ADMINISTRATOR";
            public static string PATIENT = "PATIENT";
            public static string DOCTOR = "DOCTOR";
            public static string NURSE = "NURSE";
            public static string ADMITTED = "ADMITTED";
            public static string SUPER_USER = "SUPERUSER";
        }
    }
}
