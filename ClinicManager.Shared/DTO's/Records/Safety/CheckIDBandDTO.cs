namespace ClinicManager.Shared.DTO_s.Records.Safety
{
    public class CheckIDBandDTO
    {
        public DateTime CheckIDBandsTime { get; set; }
        public int CheckIDBandsFrequency { get; set; }
        public int CheckIDBandsId{ get; set; }
        public string CheckIDBandsSignature { get; set; }
        public int PatientId { get; set; }
    }
}
