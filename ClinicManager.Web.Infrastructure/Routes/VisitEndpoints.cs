namespace ClinicManager.Web.Infrastructure.Routes
{
    public class VisitEndpoints
    {

        public static string Save = "api/Visit";

        public static string GetAllVisits = "api/Visit/GetAllVisits";

        public static string GetById(int id)
        {
            return $"api/Visit/{id}";
        }

        public static string GetAllVisitsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/Visit/GetAllVisitsTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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

        public static string GetAllVisitsByPatientIdTable(int pageNumber, int pageSize, string searchString, int patientId, string[] orderBy)
        {
            var url = $"api/Visit/GetAllVisitsByPatientIdTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&patientId={patientId}&orderBy=";
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
