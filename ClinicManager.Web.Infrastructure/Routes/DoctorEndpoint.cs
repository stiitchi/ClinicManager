namespace ClinicManager.Web.Infrastructure.Routes
{

    public class DoctorEndpoint
    {

        public static string ForLookUp = "api/Doctor/ForLookup";

        public static string Save = "api/Doctor";

        public static string GetAllDoctors = "api/Doctor/GetAllDoctors";

        public static string AssignToPatient = "api/Doctor/AssignToPatient";

        public static string GetAllDoctorByPatientId(int patientId)
        {
            return $"api/Doctor/GetAllDoctorByPatientId?patientId={patientId}";
        }

        public static string GetById(int id)
        {
            return $"api/Doctor/{id}";
        }

        public static string GetAllDoctorTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/Doctor/GetAllDoctorTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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
