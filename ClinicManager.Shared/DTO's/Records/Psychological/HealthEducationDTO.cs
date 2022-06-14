namespace ClinicManager.Shared.DTO_s.Records.Psychological
{ 
    public class HealthEducationDTO
    {
        public DateTime HealthEducationTime { get; set; }
        public int HealthEducationFrequency { get; set; }
        public int HealthEducationId { get; set; }
        public string HealthEducationSignature { get; set; }
        public int PatientId { get; set; }
    }
}
