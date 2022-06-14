
namespace ClinicManager.Shared.DTO_s.Records
{
    public class Previous24HourIntakeDTO
    {
        public int Intake24Hour { get; set; }
        public int Output24Hour { get; set; }
        public int TotalIntake { get; set; }
        public int TotalIntakeId { get; set; }
        public int PatientId { get; set; }
        public DateTime DateToday { get; set; }
    }
}
