
namespace ClinicManager.Web.Infrastructure.Routes
{
    public class DayFeeEndpoints
    {
        public static string ForLookUp = "api/DayFee/ForLookup";

        public static string Save = "api/DayFee";

        public static string GetAllDayFees = "api/DayFee/GetAllDayFees";

        public static string AssignToPatient = "api/DayFee/AddPatientDayFee";

        public static string GetAllPatientDayFees(int patientId)
        {
            return $"api/DayFee/GetAllPatientDayFees?patientId={patientId}";
        }

        public static string GetById(int id)
        {
            return $"api/DayFee/{id}";
        }

        public static string GetAllDayFeesTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/DayFee/GetAllDayFeesTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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
