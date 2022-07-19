namespace ClinicManager.Web.Infrastructure.Routes
{
    public class NurseEndpoint
    {

        public static string ForLookUp = "api/Nurse/ForLookup";

        public static string Save = "api/Nurse";

        public static string GetAllNurses = "api/Nurse/GetAllNurses";

        public static string AssignToWard = "api/Nurse/AssignToWard";

        public static string GetAllNursesByWardId(int wardId)
        {
            return $"api/Nurse/GetAllNursesByWardId?wardId={wardId}";
        }

        public static string GetById(int id)
        {
            return $"api/Nurse/{id}";
        }

        public static string GetAllNursesTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/Nurse/GetAllNursesTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
            if (orderBy?.Any() == true)
            {
                foreach (var orderByPart in orderBy)
                {
                    url += $"{orderByPart},";
                }
                url = url[..^1];
            }
            return url;
        }      
    }
}
