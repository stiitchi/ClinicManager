namespace ClinicManager.Shared.DTO_s.Records.Oxygenation
{
    public class PolyMaskDTO
    {
        public DateTime PolyMaskTime { get; set; }
        public int PolyMaskFrequency { get; set; }
        public string PolyMaskSignature { get; set; }
        public int PatientId { get; set; }
    }
}
