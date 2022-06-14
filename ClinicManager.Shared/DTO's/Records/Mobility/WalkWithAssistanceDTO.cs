namespace ClinicManager.Shared.DTO_s.Records.Mobility
{
   public class WalkWithAssistanceDTO
    {
        public DateTime WalkWithAssistanceTime { get; set; }
        public int WalkWithAssistanceFrequency { get; set; }
        public int WalkWithAssistanceId { get; set; }
        public string WalkWithAssistanceSignature { get; set; }
        public int PatientId { get; set; }
    }
}
