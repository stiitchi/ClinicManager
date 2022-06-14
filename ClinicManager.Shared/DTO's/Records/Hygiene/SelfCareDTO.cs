namespace ClinicManager.Shared.DTO_s.Records.Hygiene
{
    public class SelfCareDTO
    {
        public DateTime SelfCareTime { get; set; }
        public int SelfCareFreq { get; set; }
        public int SelfCareId { get; set; }
        public string SelfCareSignature { get; set; }
        public int PatientId { get; set; }
    }
}
