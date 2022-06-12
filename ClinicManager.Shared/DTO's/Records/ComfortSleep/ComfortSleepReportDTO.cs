namespace ClinicManager.Shared.DTO_s.Records
{
    public class ComfortSleepReportDTO
    {
        public DateTime PainControlDateTime { get; set; }
        public int Frequency { get; set; }
        public string Signature { get; set; }
        public int PatientId { get; set; }
        public int ComfortSleepRecordId { get; set; }
    }
}
