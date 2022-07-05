
namespace ClinicManager.Web.Infrastructure.Routes
{
    public class PatientEndpoint
    {
        public static string ForLookUp = "api/Patient/ForLookup";

        public static string Save = "api/Patient";

        public static string GetAllPatients = "api/Patient/GetAllPatients";

        public static string GetById(int id)
        {
            return $"api/Patient/{id}";
        }

        public static string GetPatientByIDNumber(long patientId)
        {
            return $"api/Patient/GetPatientByIDNumber?patientId={patientId}";
        }

    }
}
