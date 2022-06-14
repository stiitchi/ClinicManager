namespace ClinicManager.Shared.DTO_s.Records.Nutrition
{
    public class SpecialDTO
    {
        public DateTime SpecialTime { get; set; }
        public int SpecialFrequency { get; set; }
        public int SpecialId { get; set; }
        public string SpecialSignature { get; set; }
        public int PatientId { get; set; }
    }
}
