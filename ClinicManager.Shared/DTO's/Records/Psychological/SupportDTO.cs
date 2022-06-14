namespace ClinicManager.Shared.DTO_s.Records.Psychological
{
  public class SupportDTO
    {
        public DateTime SupportTime { get; set; }
        public int SupportFrequency { get; set; }
        public int SupportId { get; set; }
        public string SupportSignature { get; set; }
        public int PatientId { get; set; }
    }
}
