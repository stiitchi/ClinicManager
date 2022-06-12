
namespace ClinicManager.Shared.DTO_s.Records
{
    public class FluidBalanceIVCheckDTO
    {
        public int IVTestId { get; set; }
        public int PatientId { get; set; }
        public int intravenousML { get; set; }
        public int intravenousStartVolume { get; set; }
        public int intravenousCompleteVolume { get; set; }
        public int intravenousRunningTotal { get; set; }
        public bool intravenousCheck { get; set; }
        public string intravenousDesc { get; set; }
        public string intravenousCheckType { get; set; }
        public DateTime intravenousIntakeTime { get; set; }
        public DateTime intravenousIntakeTimeCompleted { get; set; }
    }
}
