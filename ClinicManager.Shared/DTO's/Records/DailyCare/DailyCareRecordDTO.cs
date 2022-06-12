
namespace ClinicManager.Shared.DTO_s.Records
{
    public class DailyCareRecordDTO
    {
        public int DailyCareRecordId { get; set; }
        public int PatientId { get; set; }
        public string CareRecord { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime TimeAdded { get; set; }
    }
}
