

namespace ClinicManager.Shared.DTO_s.Records.Observations
{
    public class UrineTestDTO
    { 
        public DateTime UrineTestTime { get; set; }
        public int UrineTestFrequency { get; set; }
        public int UrineTestId { get; set; }
        public string UrineTestSignature { get; set; }
        public int PatientId { get; set; }
    }
}
