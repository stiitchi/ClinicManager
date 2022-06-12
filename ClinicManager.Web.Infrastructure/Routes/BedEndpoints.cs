
namespace ClinicManager.Web.Infrastructure.Routes
{
    public class BedEndpoints
    {
        public static string ForLookUp = "api/Bed/ForLookup";

        public static string Save = "api/Bed";

        public static string GetAllBeds = "api/Bed/GetAllBeds";

        public static string GetById(int id)
        {
            return $"api/Bed/{id}";
        }

        public static string GetAllBedsByWardId(int wardId)
        {
            return $"api/Bed/GetAllBedsByWardId?wardId={wardId}";
        }

        public static string GetAllBedsByWardIdTable(int pageNumber, int pageSize, string searchString, int wardId, string[] orderBy)
        {
            var url = $"api/Bed/GetAllBedsByWardIdTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&wardId={wardId}&orderBy=";
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
        public static string GetAllBedsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/Bed/GetAllBedsTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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
