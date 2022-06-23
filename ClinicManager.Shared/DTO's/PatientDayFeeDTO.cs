namespace ClinicManager.Shared.DTO_s
{
     public class PatientDayFeeDTO
    {
        public int PatientId { get; set; }
        public int PatientDayFeeId { get; set; }
        public string DayFeeId { get; set; }
        public string? DayFeeCode { get; set; }
        public string? DayFeeDescription { get; set; }
    }
}
