namespace ClinicManager.Shared.DTO_s.Charts
{
    public class BloodOxygenDTO
    {
        public int BloodOxygenChartId { get; set; }
        public int PatientId { get; set; }
        public double BloodOxygenChartEntry { get; set; }
        public string Time { get; set; }

        public int BloodOxygenChartEntryId { get; set; }

    }
}
