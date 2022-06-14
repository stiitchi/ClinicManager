namespace ClinicManager.Shared.DTO_s.Records.Intervention
{
    public class PostOperativeCareDTO
    {
        public DateTime PostOperativeCareTime { get; set; }
        public int PostOperativeCareFreq { get; set; }
        public int PostOperativeCareId { get; set; }
        public string PostOperativeCareSignature { get; set; }
        public int PatientId { get; set; }
    }
}
