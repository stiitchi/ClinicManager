namespace ClinicManager.Shared.DTO_s.Records.Hygiene
{
    public class BedBathAssistDTO
    {
        public DateTime BedBathAssistTime { get; set; }
        public int BedBathAssistFreq { get; set; }
        public int BedBathAssistId { get; set; }
        public string BedBathAssistSignature { get; set; }
        public int PatientId { get; set; }
    }
}

