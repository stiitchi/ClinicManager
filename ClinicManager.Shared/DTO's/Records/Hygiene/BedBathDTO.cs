namespace ClinicManager.Shared.DTO_s.Records.Hygiene
{
    public class BedBathDTO
    {
        public DateTime BedBathTime { get; set; }
        public int BedBathFreq { get; set; }
        public int BedBathId { get; set; }
        public string BedBathSignature { get; set; }
        public int PatientId { get; set; }      
    }
}