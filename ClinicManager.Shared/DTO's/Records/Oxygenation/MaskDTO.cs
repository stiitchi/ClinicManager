namespace ClinicManager.Shared.DTO_s.Records.Oxygenation
{
    public class MaskDTO
    {
        public DateTime MaskTime { get; set; }
        public int MaskFrequency { get; set; }
        public int MaskId{ get; set; }
        public string MaskSignature { get; set; }
        public int PatientId { get; set; }
    }
}
