namespace ClinicManager.Shared.DTO_s.Patients
{
    public class VisitDTO
    {
        public int VisitId { get; set; }

        public int PatientId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ProblemDescription { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }
    }
}
