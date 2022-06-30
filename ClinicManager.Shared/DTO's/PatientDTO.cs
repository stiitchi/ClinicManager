
namespace ClinicManager.Shared.DTO_s
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public int AccountNo { get; set; }
        public int CaseInformationNumber { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public DateTime? ReportDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public long IDNo { get; set; }
        public int WardNo { get; set; }
        public int BedNo { get; set; }
        public string Location { get; set; }
        public string Language { get; set; }
        public string Stage { get; set; }
        public string Gender { get; set; }
        public string Relationship { get; set; }
        public string RefferingDoctor { get; set; }
        public string RefferingHospital { get; set; }
        public int EmergencyContactNo { get; set; }
        public long EmergencyContactIdNo { get; set; }
        public string EmergencyContactFirstName { get; set; }
        public string EmergencyContactLastName { get; set; }
        public int MedicalAidNo { get; set; }
        public string MedicalAidName { get; set; }
        public string MedicalAidOption { get; set; }
        public string DependentCode { get; set; }
        public string Race { get; set; }
        public bool OT { get; set; }
        public bool Speech { get; set; }
        public bool Psych { get; set; }
        public bool Dietician { get; set; }
        public bool SocialWorker { get; set; }
        public bool Physio { get; set; }

    }
}
