namespace ClinicManager.Shared.DTO_s.Patients
{
    public class ProblemsDTO
    {
        public int ProblemId { get; set; }

        public int PatientId { get; set; }

        public string Description { get; set; }

        public DateTime OnSetDate { get; set; }
    }
}
