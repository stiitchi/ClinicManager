namespace ClinicManager.Shared.DTO_s.Charts
{
    public class TemperatureRateDTO
    {
        public int TempRatetId { get; set; }
        public int PatientId { get; set; }
        public double TempRateEntry { get; set; }
        public string Time { get; set; }
    }
}
