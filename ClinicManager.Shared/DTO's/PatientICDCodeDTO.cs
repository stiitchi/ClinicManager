namespace ClinicManager.Shared.DTO_s
{
    public class PatientICDCodeDTO
    {
        public int PatientId { get; set; }
        public int PatientICDCodeId { get; set; }
        public string ICDCodeId { get; set; }
        public string? ICDCode { get; set; }
        public string? ICDCodeDescription { get; set; }
    }
}
