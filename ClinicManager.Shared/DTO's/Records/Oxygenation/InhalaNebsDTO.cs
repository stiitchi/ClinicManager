namespace ClinicManager.Shared.DTO_s.Records.Oxygenation
{
    public class InhalaNebsDTO
    {
        public DateTime InhalaNebsTime { get; set; }
        public int InhalaNebsFrequency { get; set; }
        public string InhalaNebsSignature { get; set; }
        public int PatientId { get; set; }
    }
}
