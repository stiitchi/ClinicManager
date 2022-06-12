namespace ClinicManager.Shared.DTO_s.Records.Intervention
{
    public class MedicationDTO
    {
        public DateTime MedicationTime { get; set; }
        public int MedicationFreq { get; set; }
        public string MedicationSignature { get; set; }
        public int PatientId { get; set; }
    }
}
