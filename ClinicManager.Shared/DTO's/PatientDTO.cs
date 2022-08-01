
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
        public string Initials { get; set; }
        public long IDNo { get; set; }
        public string WardNo { get; set; }
        public int BedNo { get; set; }
        public string PatientTelNo { get; set; }
        public string PatientCellNo { get; set; }
        public string PatientWorkTelNo { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public string PoBox { get; set; }
        public string PoBoxCode { get; set; }
        public string Occupation { get; set; }
        public string Race { get; set; }
        public string EmployerName { get; set; }
        public string Province { get; set; }
        public string WorkAddress { get; set; }
        public string WorkAddressCity { get; set; }
        public string WorkAddressProvince { get; set; }
        public string WorkAddressCode { get; set; }
        public string Language { get; set; }
        public string Gender { get; set; }

        public string NextOfKin { get; set; }
        public string NextOfKinContactNo { get; set; }
        public string RelationshipOfKin { get; set; }
        public string NextOfKinAltContactNo { get; set; }

        public string OtherContact { get; set; }
        public string OtherContactNo { get; set; }
        public string OtherContactRelationship { get; set; }
        public string OtherContactAltContactNo { get; set; }     

        public string WoundLocation { get; set; }
        public string Stage { get; set; }
        public string RefferingDoctor { get; set; }
        public string RefferingHospital { get; set; }
  
        public string MedicalAidNo { get; set; }
        public string MedicalAidName { get; set; }
        public string MedicalAidOption { get; set; }
        public string DependentCode { get; set; }
        public string AuthNo { get; set; }
        public string RoomNo { get; set; }
        public bool IsAdmitted { get; set; }

        public string MainMedicalAidMemberFirstName { get; set; }
        public string MainMedicalAidMemberLastName { get; set; }
        public string MainMedicalAidMemberTelNo { get; set; }
        public string MainMedicalAidMemberCellNo { get; set; }
        public string MainMedicalAidMemberPostalAddress { get; set; }
        public string MainMedicalAidMemberPostalAddressCode { get; set; }
        public string MainMedicalAidMemberSuburb { get; set; }
        public string MainMedicalAidMemberCity { get; set; }
        public string MainMedicalAidMemberProvince { get; set; }
        public string MainMedicalAidMemberStreetAddress { get; set; }
        public string MainMedicalAidMemberOccupation { get; set; }
        public string MainMedicalAidMemberEmployer { get; set; }
        public string MainMedicalAidMemberBusinessStreetAddress { get; set; }
        public string MainMedicalAidMemberBusinessCity { get; set; }
        public string MainMedicalAidMemberBusinessProvince { get; set; }
        public string MainMedicalAidMemberBusinessPostalCode { get; set; }
        public string MainMedicalAidMemberRelationship { get; set; }
        public long MainMedicalAidMemberIdNumber { get; set; }

        public bool OT { get; set; }
        public bool Speech { get; set; }
        public bool Psych { get; set; }
        public bool Dietician { get; set; }
        public bool SocialWorker { get; set; }
        public bool Physio { get; set; }

    }
}
