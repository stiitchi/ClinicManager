namespace ClinicManager.Shared.DTO_s.Records.Elimination
{
    public class CathetherDTO
    {
        public DateTime CatheterTime { get; set; }
        public int CatheterFreq { get; set; }
        public string CatheterSignature { get; set; }
        public int PatientId { get; set; }
        public int CatheterId { get; set; }
    }
}
