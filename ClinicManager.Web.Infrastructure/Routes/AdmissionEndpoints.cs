
namespace ClinicManager.Web.Infrastructure.Routes
{
    public class AdmissionEndpoints
    {
        public static string ForLookUp = "api/Admission/ForLookup";

        public static string AddAdmission = "api/Admission/AddAdmission";

        public static string Update = "api/Admission";

        public static string GetAllAdmissions = "api/Admission/GetAllAdmissions";

        public static string GetById(int id)
        {
            return $"api/Admission/{id}";
        }
    }
}
