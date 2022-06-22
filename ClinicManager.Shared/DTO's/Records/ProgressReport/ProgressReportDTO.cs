
namespace ClinicManager.Shared.DTO_s.Records
{
    public class ProgressReportDTO
    {
        public string Allergy { get; set; }
        public string Desc { get; set; }
        public string RiskFactor { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime TimeAdded { get; set; }
        public TimeSpan TimeAddedTS { get; set; }
        public int PatientId { get; set; }
        public int ProgressReportId { get; set; }
    }
}
