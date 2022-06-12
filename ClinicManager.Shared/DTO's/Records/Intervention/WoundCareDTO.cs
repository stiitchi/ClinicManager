namespace ClinicManager.Shared.DTO_s.Records.Intervention
{
    public class WoundCareDTO
    {
        public DateTime WoundCareTime { get; set; }
        public int WoundCareFreq { get; set; }
        public string WoundCareSignature { get; set; }
        public int PatientId { get; set; }
    }
}
