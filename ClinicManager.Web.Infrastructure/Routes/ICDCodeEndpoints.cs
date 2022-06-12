
namespace ClinicManager.Web.Infrastructure.Routes
{
    public class ICDCodeEndpoints
    {
        public static string Save = "api/ICDCode";

        public static string GetAllICDCodes = "api/ICDCode/GetAllICDCodes";

        public static string ForLookup = "api/ICDCode/ForLookup";

        public static string GetById(int id)
        {
            return $"api/ICDCode/{id}";
        }
        public static string GetAllICDCodesTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/ICDCode/GetAllICDCodesTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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
