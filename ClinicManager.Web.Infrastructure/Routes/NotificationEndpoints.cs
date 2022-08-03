namespace ClinicManager.Web.Infrastructure.Routes
{
    public class NotificationEndpoints
    {
        public static string Save = "api/Notification";

        public static string GetById(int id)
        {
            return $"api/Notification/{id}";
        }

        public static string GetAllNotificationsByTypeTable(int pageNumber, int pageSize, string searchString, string type, string[] orderBy)
        {
            var url = $"api/Notification/GetAllNotificationsByTypeTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&type={type}&orderBy=";
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

        public static string GetAllNotficationsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/Notification/GetAllNotficationsTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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
