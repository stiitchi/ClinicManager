namespace ClinicManager.Shared.DTO_s.Records.SkinIntegrity
{
    public class PressurePartCareDTO
    {
        public DateTime PressurePartCareTime { get; set; }
        public int PressurePartCareFrequency { get; set; }
        public string PressurePartCareSignature { get; set; }
        public int PatientId { get; set; }
    }
}
