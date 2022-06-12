namespace ClinicManager.Shared.DTO_s.Records.Mobility
{
   public class AssistIntoChairDTO
    {
        public DateTime AssistIntoChairTime { get; set; }
        public int AssistIntoChairFrequency { get; set; }
        public string AssistIntoChairSignature { get; set; }
        public int PatientId { get; set; }
    }
}
