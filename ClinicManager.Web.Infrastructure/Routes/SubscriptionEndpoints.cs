namespace ClinicManager.Web.Infrastructure.Routes
{
    public class SubscriptionEndpoints
    {

        public static string Save = "api/Subscription";

        public static string GetAllSubscriptions = "api/Subscription/GetAllSubscriptions";

        public static string GetSubscriptionByChecked = "api/Subscription/GetSubscriptionByChecked";


        public static string GetById(int id)
        {
            return $"api/Subscription/{id}";
        }

        public static string GetAllSubscriptionsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/Subscription/GetAllSubscriptionsTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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

        public static string GetAllCheckedSubscriptionsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/Subscription/GetAllCheckedSubscriptionsTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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
