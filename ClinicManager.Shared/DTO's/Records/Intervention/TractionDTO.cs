namespace ClinicManager.Shared.DTO_s.Records.Intervention
{
     public class TractionDTO
    {
        public DateTime TractionTime { get; set; }
        public int TractionFreq { get; set; }
        public string TractionSignature { get; set; }
        public int PatientId { get; set; }
    }
}
