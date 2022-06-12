namespace ClinicManager.Shared.DTO_s.Records.Observations
{
     public class VitalSignDTO
    {
        public DateTime VitalSignsTime { get; set; }
        public int VitalSignsFrequency { get; set; }
        public int VitalSignsId { get; set; }
        public string VitalSignSignature { get; set; }
        public int PatientId { get; set; }
    }
}
