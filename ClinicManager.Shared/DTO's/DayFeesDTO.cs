
namespace ClinicManager.Shared.DTO_s
{
    public class DayFeesDTO
    {
        public int PatientId { get; set; }
        public int DayFeeID { get; set; }
        public string DayFeeCode { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
