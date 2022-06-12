namespace ClinicManager.Shared.DTO_s.Records.FluidBalance
{
    public class OralIntakeDTO
    {
        public int PatientId { get; set; }
        public int OralIntakeTestId { get; set; }
        public int OralIntakeMl { get; set; }
        public int OralIntakeVolume { get; set; }
        public int RunningIntakeTotal { get; set; }
        public string OralCheckType { get; set; }
        public DateTime OralIntakeTime { get; set; }
    }
}
