namespace ClinicManager.Shared.DTO_s.Records.Intervention
{
    public class IsolationDTO
    {
        public DateTime IsolationTime { get; set; }
        public int IsolationFreq { get; set; }
        public string IsolationSignature { get; set; }
        public int PatientId { get; set; }
    }
}
