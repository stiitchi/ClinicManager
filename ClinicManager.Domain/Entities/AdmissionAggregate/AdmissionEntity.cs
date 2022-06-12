
using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.AdmissionAggregate
{
    public class AdmissionEntity : EntityBase
    {
        public AdmissionEntity()
        {}

        public AdmissionEntity(
           int caseInformationNo,
           int accountNo,
           DateTime admissionDate,
           DateTime admissionTime,
           string title,
           string initials,
           string surName,
           string fullName,
           int iDNo,
           DateTime dateOfBirth,
           int homeTelNo,
           int cellNo,
           int workTelNo,
           string email,
           string homeAddress,
           int postalCode,
           string poBox,
           int poBoxCode,
           string occupation,
           string language,
           string gender,
           string race,
           string employerName,
           string workAddress,
           string workAddressPostalCode,
           string nextOfKin,
           int contactNoKIn,
           string relationshipOfKin,
           int altContactNoKin,
           string otherContact,
           int otherContactNo,
           string otherContactRelationship,
           int otherContactAltNo,
           string medicalAidName,
           string medicalAidOption,
           string medicalAidNo,
           string authNo,
           string dependentCode,
           string medicalAidMemberFullName,
           int medicalAidMemberIdNo,
           string medicalAidMemberRelationship,
           int medicalAidMemberTelNo,
           int medicalAidMemberCellNo,
           string medicalAidMemberPostalAddress,
           string medicalAidMemberPostalAddressCode,
           string medicalAidMemberHomeAddress,
           string medicalAidMemberHomePostalCode,
           string medicalAidMemberOccupation,
           string medicalAidMemberEmployerName,
           string medicalAidMemberBusinessAddress,
           string medicalAidMemberBusinessPostalCode
            )
        {
            _caseInformationNo = caseInformationNo;
            _accountNo = accountNo;
            _admissionDate = admissionDate;
            _admissionTime = admissionTime;
            _title = title;
            _initials = initials;
            _lastName = surName;
            _fullName = fullName;
            _IDNo = iDNo;
            _dateOfBirth = dateOfBirth;
            _homeTelNo = homeTelNo;
            _cellNo = cellNo;
            _workTelNo = workTelNo;
            _email = email;
            _homeAddress = homeAddress;
            _postalCode = postalCode;
            _poBox = poBox;
            _poBoxCode = poBoxCode;
            _occupation = occupation;
            _language = language;
            _gender = gender;
            _race = race;
            _employerName = employerName;
            _workAddress = workAddress;
            _workAddressPostalCode = workAddressPostalCode;
            _nextOfKin = nextOfKin;
            _contactNoKin = contactNoKIn;
            _relationshipOfKin = relationshipOfKin;
            _altContactNoKin = altContactNoKin;
            _otherContact = otherContact;
            _otherContactRelationship = otherContactRelationship;
            _otherContactNo = otherContactNo;
            _otherContactNoAlt = otherContactAltNo;
            _medicalAidNo = medicalAidNo;
            _medicalAidName = medicalAidName;
            _medicalAidOption = medicalAidOption;
            _authNo = authNo;
            _dependentCode = dependentCode;
            _medicalAidMemberFullName = medicalAidMemberFullName;
            _medicalAidMemberIdNo = medicalAidMemberIdNo;
            _medicalAidMemberRelationship = medicalAidMemberRelationship;   
            _medicalAidMemberTelNo = medicalAidMemberTelNo;
            _medicalAidMemberCellNo = medicalAidMemberCellNo;
            _medicalAidMemberPostalAddress = medicalAidMemberPostalAddress;
            _medicalAidMemberPostalAddressCode = medicalAidMemberPostalAddressCode;
            _medicalAidMemberHomeAddress = medicalAidMemberHomeAddress;
            _medicalAidMemberHomePostalCode = medicalAidMemberHomePostalCode;
            _medicalAidMemberOccupation = medicalAidMemberOccupation;
            _medicalAidMemberEmployer = medicalAidMemberEmployerName;
            _medicalAidMemberBusinessAddress = medicalAidMemberBusinessAddress;
            _medicalAidMemberBusinessPostalCode = medicalAidMemberBusinessPostalCode;
        }

        public void Set(
           int caseInformationNo,
           int accountNo,
           DateTime admissionDate,
           DateTime admissionTime,
           string title,
           string initials,
           string surName,
           string fullName,
           int iDNo,
           DateTime dateOfBirth,
           int homeTelNo,
           int cellNo,
           int workTelNo,
           string email,
           string homeAddress,
           int postalCode,
           string poBox,
           int poBoxCode,
           string occupation,
           string language,
           string gender,
           string race,
           string employerName,
           string workAddress,
           string workAddressPostalCode,
           string nextOfKin,
           int contactNoKIn,
           string relationshipOfKin,
           int altContactNoKin,
           string otherContact,
           int otherContactNo,
           string otherContactRelationship,
           int otherContactAltNo,
           string medicalAidName,
           string medicalAidOption,
           string medicalAidNo,
           string authNo,
           string dependentCode,
           string medicalAidMemberFullName,
           int medicalAidMemberIdNo,
           string medicalAidMemberRelationship,
           int medicalAidMemberTelNo,
           int medicalAidMemberCellNo,
           string medicalAidMemberPostalAddress,
           string medicalAidMemberPostalAddressCode,
           string medicalAidMemberHomeAddress,
           string medicalAidMemberHomePostalCode,
           string medicalAidMemberOccupation,
           string medicalAidMemberEmployerName,
           string medicalAidMemberBusinessAddress,
           string medicalAidMemberBusinessPostalCode
           )
        {
            _caseInformationNo = caseInformationNo;
            _accountNo = accountNo;
            _admissionDate = admissionDate;
            _admissionTime = admissionTime;
            _title = title;
            _initials = initials;
            _lastName = surName;
            _fullName = fullName;
            _IDNo = iDNo;
            _dateOfBirth = dateOfBirth;
            _homeTelNo = homeTelNo;
            _cellNo = cellNo;
            _workTelNo = workTelNo;
            _email = email;
            _homeAddress = homeAddress;
            _postalCode = postalCode;
            _poBox = poBox;
            _poBoxCode = poBoxCode;
            _occupation = occupation;
            _language = language;
            _gender = gender;
            _race = race;
            _employerName = employerName;
            _workAddress = workAddress;
            _workAddressPostalCode = workAddressPostalCode;
            _nextOfKin = nextOfKin;
            _contactNoKin = contactNoKIn;
            _relationshipOfKin = relationshipOfKin;
            _altContactNoKin = altContactNoKin;
            _otherContact = otherContact;
            _otherContactRelationship = otherContactRelationship;
            _otherContactNo = otherContactNo;
            _otherContactNoAlt = otherContactAltNo;
            _medicalAidNo = medicalAidNo;
            _medicalAidName = medicalAidName;
            _medicalAidOption = medicalAidOption;
            _authNo = authNo;
            _dependentCode = dependentCode;
            _medicalAidMemberFullName = medicalAidMemberFullName;
            _medicalAidMemberIdNo = medicalAidMemberIdNo;
            _medicalAidMemberRelationship = medicalAidMemberRelationship;
            _medicalAidMemberTelNo = medicalAidMemberTelNo;
            _medicalAidMemberCellNo = medicalAidMemberCellNo;
            _medicalAidMemberPostalAddress = medicalAidMemberPostalAddress;
            _medicalAidMemberPostalAddressCode = medicalAidMemberPostalAddressCode;
            _medicalAidMemberHomeAddress = medicalAidMemberHomeAddress;
            _medicalAidMemberHomePostalCode = medicalAidMemberHomePostalCode;
            _medicalAidMemberOccupation = medicalAidMemberOccupation;
            _medicalAidMemberEmployer = medicalAidMemberEmployerName;
            _medicalAidMemberBusinessAddress = medicalAidMemberBusinessAddress;
            _medicalAidMemberBusinessPostalCode = medicalAidMemberBusinessPostalCode;
        }



        private int _caseInformationNo;
        public int CaseInformationNo =>_caseInformationNo;

        private int _accountNo;
        public int AccountNo => _accountNo;

        private DateTime _admissionDate;
        public DateTime AdmissionDate => _admissionDate;

        private DateTime _admissionTime;
        public DateTime AdmissionTime => _admissionTime;

        private string _fullName;
        public string FullName => _fullName;

        private string _lastName;
        public string LastName => _lastName;

        private string _title;
        public string Title => _title;

        private string _initials;
        public string Initials => _initials;

        private int _IDNo;
        public int IDNo => _IDNo;

        private int _homeTelNo;
        public int HomeTelNo => _homeTelNo;

        private int _workTelNo;
        public int WorkTelNo => _workTelNo;

        private int _cellNo;
        public int CellNo => _cellNo;

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth => _dateOfBirth;

        private int _postalCode;
        public int PostalCode => _postalCode;

        private string _homeAddress;
        public string HomeAddress => _homeAddress;

        private string _poBox;
        public string PoBox => _poBox;

        private int _poBoxCode;
        public int PoBoxCode => _poBoxCode; 
        
        private string _occupation;
        public string Occupation => _occupation;

        private string _language;
        public string Language => _language;

        private string _gender;
        public string Gender => _gender;

        private string _race;
        public string Race => _race;

        private string _email;
        public string Email => _email;

        private string _employerName;
        public string EmployerName => _employerName;

        private string _workAddress;
        public string WorkAddress => _workAddress;

        private string _workAddressPostalCode;
        public string WorkAddressPostalCode => _workAddressPostalCode;

        private string _nextOfKin;
        public string NextOfKin => _nextOfKin;

        private string _relationshipOfKin;
        public string RelationshipOfKin => _relationshipOfKin;

        private string _otherContact;
        public string OtherContact => _otherContact;

        private string _otherContactRelationship;
        public string OtherContactRelationship => _otherContactRelationship;

        private string _medicalAidNo;
        public string MedicalAidNo => _medicalAidNo;

        private string _medicalAidName;
        public string MedicalAidName=> _medicalAidName;

        private string _medicalAidOption;
        public string MedicalAidOption => _medicalAidOption;

        private string _authNo;
        public string AuthNo => _authNo;

        private string _dependentCode;
        public string DependentCode => _dependentCode;

        private string _medicalAidMemberFullName;
        public string MedicalAidMemberFullName => _medicalAidMemberFullName;

        private string _medicalAidMemberRelationship;
        public string MedicalAidMemberRelationship => _medicalAidMemberRelationship;

        private string _medicalAidMemberHomeAddress;
        public string MedicalAidMemberHomeAddress => _medicalAidMemberHomeAddress;

        private string _medicalAidMemberHomePostalCode;
        public string MedicalAidMemberHomePostalCode => _medicalAidMemberHomePostalCode;

        private string _medicalAidMemberPostalAddressCode;
        public string MedicalAidMemberPostalAddressCode => _medicalAidMemberPostalAddressCode;

        private string _medicalAidMemberPostalAddress;
        public string MedicalAidMemberPostalAddress => _medicalAidMemberPostalAddress;

        private string _medicalAidMemberOccupation;
        public string MedicalAidMemberOccupation => _medicalAidMemberOccupation;

        private string _medicalAidMemberEmployer;
        public string MedicalAidMemberEmployer => _medicalAidMemberEmployer;

        private string _medicalAidMemberBusinessAddress;
        public string MedicalAidMemberBusinessAddress => _medicalAidMemberBusinessAddress;

        private string _medicalAidMemberBusinessPostalCode;
        public string MedicalAidMemberBusinessPostalCode => _medicalAidMemberBusinessPostalCode;

        private int _medicalAidMemberIdNo;
        public int MedicalAidMemberIdNo => _medicalAidMemberIdNo;

        private int _medicalAidMemberTelNo;
        public int MedicalAidMemberTelNo => _medicalAidMemberTelNo;

        private int _medicalAidMemberCellNo;
        public int MedicalAidMemberCellNo => _medicalAidMemberCellNo;

        private int _medicalAidMemberPostalCode;
        public int MedicalAidMemberPostalCode => _medicalAidMemberPostalCode;

        private int _otherContactNo;
        public int OtherContactNo => _otherContactNo;

        private int _altContactNoKin;
        public int AltContactNoKin => _altContactNoKin;

        private int _otherContactNoAlt;
        public int OtherContactNoAlt => _otherContactNoAlt;

        private int _contactNoKin;
        public int ContactNoKin => _contactNoKin;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;

    }
}
