
namespace ClinicManager.Web.Infrastructure.Routes
{
    public class PatientEndpoint
    {
        public static string ForLookUp = "api/Patient/ForLookup";

        public static string Save = "api/Patient";

        public static string GetAllPatients = "api/Patient/GetAllPatients";
        public static string GetAllAdmittedPatients = "api/Patient/GetAllAdmittedPatients";

        public static string GetById(int id)
        {
            return $"api/Patient/{id}";
        }
        public static string DischargePatient(int patientId)
        {
            return $"api/Patient/DischargePatient?patientId={patientId}";
        }
        
        public static string GetAllPatientsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/Patient/GetAllPatientsTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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

        public static string GetAllAdmittedPatientsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/Patient/GetAllAdmittedPatientsTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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

        public static string GetPatientByIDNumber(long patientId)
        {
            return $"api/Patient/GetPatientByIDNumber?patientId={patientId}";
        }

    }
}
