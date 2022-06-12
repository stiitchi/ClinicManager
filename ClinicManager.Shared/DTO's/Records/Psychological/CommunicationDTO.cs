namespace ClinicManager.Shared.DTO_s.Records.Psychological
{ 
    public class CommunicationDTO
    {
        public DateTime CommunicationTime { get; set; }
        public int CommunicationFrequency { get; set; }
        public string CommunicationSignature { get; set; }
        public int PatientId { get; set; }
    }
}
