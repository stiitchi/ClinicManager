namespace ClinicManager.Shared.DTO_s.Records.Observations
{
     public class BloodGlucoseDTO
    {
        public DateTime BloodGlucoseTime { get; set; }
        public int BloodGlucoseFrequency { get; set; }
        public int BloodGlucoseId { get; set; }
        public string BloodGlucoseSignature { get; set; }
        public int PatientId { get; set; }
    }
}
