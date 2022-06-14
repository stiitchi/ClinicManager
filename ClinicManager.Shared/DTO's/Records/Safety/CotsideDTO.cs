namespace ClinicManager.Shared.DTO_s.Records.Safety
{
    public class CotsideDTO
    {
        public DateTime CotsidesTime { get; set; }
        public int CotsidesFrequency { get; set; }
        public int CotsidesId { get; set; }
        public string CotsidesSignature { get; set; }
        public int PatientId { get; set; }
    }
}
