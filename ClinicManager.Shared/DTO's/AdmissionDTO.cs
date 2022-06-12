
namespace ClinicManager.Shared.DTO_s
{
    public class AdmissionDTO
    {
        public int AdmissionId { get; set; }
        public int CaseInformationNumber { get; set; }
        public int AccountNo { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime AdmissionTime { get; set; }
        public string Email { get; set; }
        public string PatientFullName { get; set; }
        public string MedicalAidMemberFullName { get; set; }
        public string MedicalAidMemberRelationship { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Initials { get; set; }
        public int IDNo { get; set; }
        public int MedicalAidMemberIdNo { get; set; }
        public int HomeTelNo { get; set; }
        public int WorkTelNo { get; set; }
        public int MedicalAidMemberTelNo { get; set; }
        public int CellNo { get; set; }
        public int MedicalAidMemberCellNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MedicalAidMemberEmployerName { get; set; }
        public string MedicalAidMemberPostalAddress { get; set; }
        public string MedicalAidMemberPostalAddressCode { get; set; }
        public string MedicalAidMemberHomeAddress { get; set; }
        public string MedicalAidMemberHomePostalCode { get; set; }
        public string HomeAddress { get; set; }
        public int HomePostalCode { get; set; }
        public string POBox { get; set; }
        public int POBoxCode { get; set; }
        public string Occupation { get; set; }
        public string MedicalAidMemberOccupation { get; set; }
        public string Language { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string EmployerName { get; set; }
        public string WorkAddress { get; set; }
        public string WorkAddressPostalCode { get; set; }
        public string NextOfKin { get; set; }
        public int ContactNoKin { get; set; }  
        public string RelationshipOfKin { get; set; }  
        public string OtherContact { get; set; }
        public int OtherContactNo { get; set; }
        public int AltContactNoKin { get; set; }
        public int OtherContactNoAlt { get; set; }
        public string OtherContactRelationship { get; set; }
        public string MedicalAidNo { get; set; }
        public string MedicalAidName { get; set; }
        public string MedicalAidOption { get; set; }
        public string AuthNo { get; set; }
        public string DependentCode { get; set; }
        public string MedicalAidMemberBusinessAddress { get; set; }
        public string MedicalAidMemberBusinessPostalCode { get; set; }
    }
}
