
namespace ClinicManager.Web.Infrastructure.Routes
{
    public class WardEndpoint
    {
        public static string ForLookUp = "api/Ward/ForLookup";

        public static string Save = "api/Ward";

        public static string GetAllWards = "api/Ward/GetAllWards";

        public static string GetById(int id)
        {
            return $"api/Ward/{id}";
        }
        public static string GetWardsByWardNumber(string wardNumber)
        {
            return $"api/Ward/GetWardsByWardNumber?wardNumber={wardNumber}";
        }
        

        public static string GetAllWardsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/Ward/GetAllWardsTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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
