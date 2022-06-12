namespace ClinicManager.Shared.DTO_s.Records.Observations
{
    public class BloodDTO
    {
        public DateTime BloodTime { get; set; }
        public int BloodFrequency { get; set; }
        public int BloodFrequencyId { get; set; }
        public string BloodSignature { get; set; }
        public int PatientId { get; set; }
    }
}
