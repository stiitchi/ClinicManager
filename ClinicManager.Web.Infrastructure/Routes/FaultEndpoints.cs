namespace ClinicManager.Web.Infrastructure.Routes
{
    public class FaultEndpoints
    {
        public static string Save = "api/Fault";

        public static string GetById(int id)
        {
            return $"api/Fault/{id}";
        }

        public static string GetAllFaultsBySeverityTable(int pageNumber, int pageSize, string searchString, string severity, string[] orderBy)
        {
            var url = $"api/Fault/GetAllFaultsBySeverityTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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

        public static string GetAllFaultsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/Fault/GetAllFaultsTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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
