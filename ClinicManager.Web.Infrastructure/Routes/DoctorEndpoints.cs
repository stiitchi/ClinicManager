
namespace ClinicManager.Web.Infrastructure.Routes
{
   public class DoctorEndpoints
    {
        public static string ForLookUp = "api/Doctor/ForLookup";

        public static string Save = "api/Doctor";

        public static string GetAllBeds = "api/Doctor/GetAllBeds";

        public static string GetById(int id)
        {
            return $"api/Bed/{id}";
        }
    }
}
