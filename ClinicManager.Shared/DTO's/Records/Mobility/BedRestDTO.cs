namespace ClinicManager.Shared.DTO_s.Records.Mobility
{
     public class BedRestDTO
    {
        public DateTime BedRestTime { get; set; }
        public int BedRestFrequency { get; set; }
        public string BedRestSignature { get; set; }
        public int PatientId { get; set; }
    }
}
