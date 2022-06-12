namespace ClinicManager.Shared.DTO_s.Records.Oxygenation
{
    public class NasalCannulaDTO
    {
        public DateTime NasalCannulaTime { get; set; }
        public int NasalCannulaFrequency { get; set; }
        public string NasalCannulaSignature { get; set; }
        public int PatientId { get; set; }
    }
}
