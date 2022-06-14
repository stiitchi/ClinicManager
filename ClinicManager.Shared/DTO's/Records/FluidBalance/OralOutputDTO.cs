namespace ClinicManager.Shared.DTO_s.Records.FluidBalance
{
      public class OralOutputDTO
    {
        public int PatientId { get; set; }
        public int OralOutputTestId { get; set; }
        public int RunningOutputTotal { get; set; }
        public int OralOutputMl { get; set; }
        public bool IsUrine { get; set; }
        public DateTime OralOutputTime { get; set; }
    }
}
