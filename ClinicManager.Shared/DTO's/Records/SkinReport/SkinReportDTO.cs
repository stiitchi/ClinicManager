namespace ClinicManager.Shared.DTO_s.Records.SkinReport
{ 
    public class SkinReportDTO
    {
        public string SacrumDescription { get; set; }
        public string HipsDescription { get; set; }
        public string HealsDescription { get; set; }
        public string OtherDescription { get; set; }
        public string Comments { get; set; }
        public int PatientId { get; set; }
        public int SkinIntegrityId { get; set; }
    }
}
