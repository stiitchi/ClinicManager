using ClinicManager.Domain.Entities.BedAggregate;
using ClinicManager.Domain.Entities.ChartsAggregate;
using ClinicManager.Domain.Entities.DayFeesAggregate;
using ClinicManager.Domain.Entities.ICDCodeAggregate;
using ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanFluids;
using ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanSkinIntegrity;
using ClinicManager.Domain.Entities.PatientAggregate.Records.ComfortSleep;
using ClinicManager.Domain.Entities.PatientAggregate.Records.DailyCare;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Elimination;
using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using ClinicManager.Domain.Entities.PatientAggregate.Records.ProgressRecords;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Safety;
using ClinicManager.Domain.Entities.PatientAggregate.Records.SkinIntegrity;
using ClinicManager.Domain.Entities.PatientAggregate.Records.StoolCharts;

namespace ClinicManager.Domain.Entities.PatientAggregate
{
    public class PatientEntity : EntityBase
    {
        // add notes
        // add othermembers
        // add hopsitals and doctors
        // BG, INR, IVI, INHAL

        public PatientEntity()
        { }
        public PatientEntity(
           string wardNo,
           int bedNo,
           int caseInformationNumber,
           int accountNo,
           DateTime? admissionDate,
           DateTime? dateOfBirth,
           DateTime? dischargeDate,
           DateTime? reportDate,
           string title,
           string initials,
           string fullName,
           string lastName,
           long idNo,
           string telNo,
           string cellNo,
           string telNoWork,
           string email,
           string streetAddress,
           string suburb,
           string city,
           string province, 
           string postalCode,
           string poBox,
           string poBoxCode,
           string occupation,
           string language,
           string gender,
           string race, 
           string employerName, 
           string workStreetAddress,
           string workAddressCity,
           string workAddressProvince,
           string workAddressPostalCode,
           string nextOfKin,
           string nextOfKinContactNo,
           string nextOfKinRelationship,
           string nextOfKinAltContactNo,
           string nextOfKinOtherContact,
           string nextOfKinOtherContactNo,
           string nextOfKinOtherRelationship,
           string nextOfKinOtherAltContactNo,
           string refferingDoctor,
           string refferingHospital,
           string medicalAidName,
           string medicalAidOption,
           string medicalAidNo,
           string authNo,
           string dependentCode,
           string woundLocation,
           string woundStage,
           bool ot,
           bool speech,
           bool psych,
           bool dietician,
           bool socialWorker,
           bool physio,
           string memberAidFirstName,
           string memberAidLastName,
           long memberIdNo,
           string memberRelationship,
           string memberTelNo,
           string memberCellNo,
           string memberHomeAddress,
           string memberHomeAddressCity,
           string memberHomeAddressSuburb,
           string memberHomeAddressProvince,
           string memberPostalAddress,
           string memberPostalAddressCode,
           string memberOccupation,
           string memberEmployer,
           string memberBusinessAddress,
           string memberBusinessAddressCity,
           string memberBusinessAddressProvince,
           string memberBusinessAddressPostalCode
        )
        {
            _wardNO = wardNo;
            _bedNO = bedNo;
            _caseInfomationNo = caseInformationNumber;
            _accountNO = accountNo;
            _admissionDate = admissionDate;
            _dateOfBirth = dateOfBirth;
            _dischargeDate = dischargeDate;
            _reportDate = reportDate;
            _title = title;
            _initials = initials;
            _firstName = fullName;
            _lastName = lastName;
            _IDNo = idNo;
            _patientTelNo = telNo;
            _patientCellNo = cellNo;
            _patientWorkTelNo = telNoWork;
            _email = email;
            _streetAddress = streetAddress;
            _suburb = suburb;
            _city = city;
            _province = province;
            _postalCode = postalCode;
            _poBox = poBox;
            _poBoxCode = poBoxCode;
            _occupation = occupation;
            _language = language;
            _gender = gender;
            _race = race;
            _employerName = employerName;
            _workAddress = workStreetAddress;
            _workAddressCity = workAddressCity;
            _workAddressProvince = workAddressProvince;
            _workAddressPostalCode = workAddressPostalCode;
            _nextOfKin = nextOfKin;
            _nextOfKinContactNo = nextOfKinContactNo;
            _nextOfKinRelationship = nextOfKinRelationship;
            _nextOfKinAltContactNo = nextOfKinAltContactNo;
            _otherContact = nextOfKinOtherContact;
            _otherContactNo = nextOfKinOtherContactNo;
            _otherContactRelationship = nextOfKinOtherRelationship;
            _otherContactAltContactNo = nextOfKinOtherAltContactNo;
            _refferingDoctor= refferingDoctor;
            _refferingHospital= refferingHospital;
            _medicalAidName= medicalAidName;
            _medicalAidOption = medicalAidOption;
            _medicalAidNo = medicalAidNo;
            _dependentCode = dependentCode;
            _authNo = authNo;
            _woundLocation = woundLocation;
            _woundStage = woundStage;
            _ot = ot;
            _speechLanguage = speech;
            _psychologist = psych;
            _dietician = dietician;
            _socialWorker = socialWorker;
            _physio = physio;
            _mainMemberFirstName = memberAidFirstName;
            _mainMemberLastName = memberAidLastName;
            _medicalAidIdNumber = memberIdNo;
            _mainMemberRelationship = memberRelationship;
            _mainMemberTelNo = memberTelNo; 
            _mainMemberCellNo = memberCellNo;
            _mainMemberStreetAddress = memberHomeAddress;
            _mainMemberSuburb = memberHomeAddressSuburb;
            _mainMemberCity = memberHomeAddressCity;
            _mainMemberProvince = memberHomeAddressProvince;
            _mainMemberPostalAddress = memberPostalAddress;
            _mainMemberPostalAddressCode = memberPostalAddressCode;
            _mainMemberOccupation = memberOccupation;
            _mainMemberEmployer = memberEmployer;
            _mainMemberBusinessStreetAddress = memberBusinessAddress;
            _mainMemberBusinessCity = memberBusinessAddressCity;
            _mainMemberBusinessProvince = memberBusinessAddressProvince;
            _mainMemberBusinessPostalCode = memberBusinessAddressPostalCode;
        }
        public void Set(
          string wardNo,
          int bedNo,
          int caseInformationNumber,
          int accountNo,
          DateTime? admissionDate,
          DateTime? dateOfBirth,
          DateTime? dischargeDate,
          DateTime? reportDate,
          string title,
          string initials,
          string fullName,
          string lastName,
          long idNo,
          string telNo,
          string cellNo,
          string telNoWork,
          string email,
          string streetAddress,
          string suburb,
          string city,
          string province,
          string postalCode,
          string poBox,
          string poBoxCode,
          string occupation,
          string language,
          string gender,
          string race,
          string employerName,
          string workStreetAddress,
          string workAddressCity,
          string workAddressProvince,
          string workAddressPostalCode,
          string nextOfKin,
          string nextOfKinContactNo,
          string nextOfKinRelationship,
          string nextOfKinAltContactNo,
          string nextOfKinOtherContact,
          string nextOfKinOtherContactNo,
          string nextOfKinOtherRelationship,
          string nextOfKinOtherAltContactNo,
          string refferingDoctor,
          string refferingHospital,
          string medicalAidName,
          string medicalAidOption,
          string medicalAidNo,
          string authNo,
          string dependentCode,
          string woundLocation,
          string woundStage,
          bool ot,
          bool speech,
          bool psych,
          bool dietician,
          bool socialWorker,
          bool physio,
          string memberAidFirstName,
          string memberAidLastName,
          long memberIdNo,
          string memberRelationship,
          string memberTelNo,
          string memberCellNo,
          string memberHomeAddress,
          string memberHomeAddressCity,
          string memberHomeAddressSuburb,
          string memberHomeAddressProvince,
          string memberPostalAddress,
          string memberPostalAddressCode,
          string memberOccupation,
          string memberEmployer,
          string memberBusinessAddress,
          string memberBusinessAddressCity,
          string memberBusinessAddressProvince,
          string memberBusinessAddressPostalCode
       )
        {
            _wardNO = wardNo;
            _bedNO = bedNo;
            _caseInfomationNo = caseInformationNumber;
            _accountNO = accountNo;
            _admissionDate = admissionDate;
            _dateOfBirth = dateOfBirth;
            _dischargeDate = dischargeDate;
            _reportDate = reportDate;
            _title = title;
            _initials = initials;
            _firstName = fullName;
            _lastName = lastName;
            _IDNo = idNo;
            _patientTelNo = telNo;
            _patientCellNo = cellNo;
            _patientWorkTelNo = telNoWork;
            _email = email;
            _streetAddress = streetAddress;
            _suburb = suburb;
            _city = city;
            _province = province;
            _postalCode = postalCode;
            _poBox = poBox;
            _poBoxCode = poBoxCode;
            _occupation = occupation;
            _language = language;
            _gender = gender;
            _race = race;
            _employerName = employerName;
            _workAddress = workStreetAddress;
            _workAddressCity = workAddressCity;
            _workAddressProvince = workAddressProvince;
            _workAddressPostalCode = workAddressPostalCode;
            _nextOfKin = nextOfKin;
            _nextOfKinContactNo = nextOfKinContactNo;
            _nextOfKinRelationship = nextOfKinRelationship;
            _nextOfKinAltContactNo = nextOfKinAltContactNo;
            _otherContact = nextOfKinOtherContact;
            _otherContactNo = nextOfKinOtherContactNo;
            _otherContactRelationship = nextOfKinOtherRelationship;
            _otherContactAltContactNo = nextOfKinOtherAltContactNo;
            _refferingDoctor = refferingDoctor;
            _refferingHospital = refferingHospital;
            _medicalAidName = medicalAidName;
            _medicalAidOption = medicalAidOption;
            _medicalAidNo = medicalAidNo;
            _dependentCode = dependentCode;
            _authNo = authNo;
            _woundLocation = woundLocation;
            _woundStage = woundStage;
            _ot = ot;
            _speechLanguage = speech;
            _psychologist = psych;
            _dietician = dietician;
            _socialWorker = socialWorker;
            _physio = physio;
            _mainMemberFirstName = memberAidFirstName;
            _mainMemberLastName = memberAidLastName;
            _medicalAidIdNumber = memberIdNo;
            _mainMemberRelationship = memberRelationship;
            _mainMemberTelNo = memberTelNo;
            _mainMemberCellNo = memberCellNo;
            _mainMemberStreetAddress = memberHomeAddress;
            _mainMemberSuburb = memberHomeAddressSuburb;
            _mainMemberCity = memberHomeAddressCity;
            _mainMemberProvince = memberHomeAddressProvince;
            _mainMemberPostalAddress = memberPostalAddress;
            _mainMemberPostalAddressCode = memberPostalAddressCode;
            _mainMemberOccupation = memberOccupation;
            _mainMemberEmployer = memberEmployer;
            _mainMemberBusinessStreetAddress = memberBusinessAddress;
            _mainMemberBusinessCity = memberBusinessAddressCity;
            _mainMemberBusinessProvince = memberBusinessAddressProvince;
            _mainMemberBusinessPostalCode = memberBusinessAddressPostalCode;
        }

        private string _authNo;
        public string AuthNo => _authNo;

        private string _streetAddress;
        public string StreetAddress => _streetAddress;

        private string _suburb;
        public string Suburb => _suburb;

        private string _city;

        private string _postalCode;
        public string PostalCode => _postalCode;
        public string City => _city;

        private string _province;
        public string Province => _province;

        private string _email;
        public string Email => _email;

        private string _patientCellNo;
        public string PatientCellNo => _patientCellNo;

        private string _patientTelNo;
        public string PatientTelNo => _patientTelNo;

        private string _patientWorkTelNo;
        public string PatientWorkTelNo => _patientWorkTelNo;

        private string _initials;
        public string Initials => _initials;

        private string _dependentCode;
        public string DependentCode => _dependentCode;

        private string _refferingDoctor;
        public string RefferingDoctor => _refferingDoctor;

        private string _refferingHospital;
        public string RefferingHospital => _refferingHospital;

        private string _relationship;
        public string Relationship => _relationship;

        private string _gender;
        public string Gender => _gender;

        private string _race;
        public string Race => _race;

        private string _language;
        public string Language => _language;

        private string _poBox;
        public string PoBox => _poBox;

        private string _poBoxCode;
        public string PoBoxCode => _poBoxCode;

        private string _occupation;
        public string Occupation => _occupation;

        private string _employerName;
        public string EmployerName => _employerName;

        private string _workAddressCity;
        public string WorkAddressCity => _workAddressCity;

        private string _workAddressProvince;
        public string WorkAddressProvince => _workAddressProvince;

        private string _workAddressPostalCode;
        public string WorkAddressPostalCode => _workAddressPostalCode;


        private string _nextOfKin;
        public string NextOfKin => _nextOfKin;

        private string _nextOfKinContactNo;
        public string NextOfKinContactNo => _nextOfKinContactNo;

        private string _nextOfKinRelationship;
        public string NextOfKinRelationship => _nextOfKinRelationship;

        private string _nextOfKinAltContactNo;
        public string NextOfKinAltContactNo => _nextOfKinAltContactNo;

        private string _otherContact;
        public string OtherContact => _otherContact;

        private string _otherContactNo;
        public string OtherContactNo => _otherContactNo;

        private string _otherContactRelationship;
        public string OtherContactRelationship => _otherContactRelationship;

        private string _otherContactAltContactNo;
        public string OtherContactAltContactNo => _otherContactAltContactNo;

        private string _workAddress;
        public string WorkAddress => _workAddress;

        private int _emergencyContactNo;
        public int EmergencyContactNo => _emergencyContactNo;

        private string _wardNO;
        public string WardNO => _wardNO;

        private int _bedNO;
        public int BedNO => _bedNO;

        private DateTime? _dateOfBirth;
        public DateTime? DateOfBirth => _dateOfBirth;

        private DateTime? _admissionDate;
        public DateTime? AdmissionDate => _admissionDate;

        private DateTime? _dischargeDate;
        public DateTime? DischargeDate => _dischargeDate;

        private DateTime? _reportDate;
        public DateTime? ReportDate => _reportDate;

        private string _firstName;
        public string FirstName => _firstName;

        private string _lastName;
        public string LastName => _lastName;

        private string _title;
        public string Title => _title;

        private long _IDNo;
        public long IDNo => _IDNo;

        private int _caseInfomationNo;
        public int CaseInfomationNo => _caseInfomationNo;

        private int _accountNO;
        public int AccountNO => _accountNO;

        private string _medicalAidNo;
        public string MedicalAidNo => _medicalAidNo;

        private string _woundLocation;
        public string WoundLocation => _woundLocation;

        private string _woundStage;
        public string WoundStage => _woundStage;

        private string _mainMemberFirstName;
        public string MainMemberFirstName => _mainMemberFirstName;

        private string _mainMemberLastName;
        public string MainMemberLastName => _mainMemberLastName;

        private string _mainMemberTelNo;
        public string MainMemberTelNo => _mainMemberTelNo;

        private string _mainMemberStreetAddress;
        public string MainMemberStreetAddress => _mainMemberStreetAddress;

        private string _mainMemberCellNo;
        public string MainMemberCellNo => _mainMemberCellNo;

        private string _mainMemberPostalAddress;
        public string MainMemberPostalAddress => _mainMemberPostalAddress;

        private string _mainMemberPostalAddressCode;
        public string MainMemberPostalAddressCode => _mainMemberPostalAddressCode;

        private string _mainMemberOccupation;
        public string MainMemberOccupation => _mainMemberOccupation;

        private string _mainMemberEmployer;
        public string MainMemberEmployer => _mainMemberEmployer;

        private string _mainMemberBusinessStreetAddress;
        public string MainMemberBusinessStreetAddress => _mainMemberBusinessStreetAddress;

        private string _mainMemberBusinessCity;
        public string MainMemberBusinessCity => _mainMemberBusinessCity;

        private string _mainMemberBusinessProvince;
        public string MainMemberBusinessProvince => _mainMemberBusinessProvince;

        private string _mainMemberBusinessPostalCode;
        public string MainMemberBusinessPostalCode => _mainMemberBusinessPostalCode;

        private string _mainMemberSuburb;
        public string MainMemberSuburb => _mainMemberSuburb;

        private string _mainMemberCity;
        public string MainMemberCity => _mainMemberCity;

        private string _mainMemberProvince;
        public string MainMemberProvince => _mainMemberProvince;

        private string _mainMemberRelationship;
        public string MainMemberRelationship => _mainMemberRelationship;

        private string _medicalAidName;
        public string MedicalAidName => _medicalAidName;

        private long _medicalAidIdNumber;
        public long MedicalAidIdNumber => _medicalAidIdNumber;

        private string _medicalAidOption;
        public string MedicalAidOption => _medicalAidOption;

        private bool _speechLanguage;
        public bool SpeechLanguage => _speechLanguage;

        private bool _psychologist;
        public bool Psychologist => _psychologist;

        private bool _dietician;
        public bool Dietician => _dietician;

        private bool _socialWorker;
        public bool SocialWorker => _socialWorker;

        private bool _physio;
        public bool Physio => _physio;

        private bool _ot;
        public bool Ot => _ot;

        private readonly List<BloodOxygenChartEntity> _bloodOxygenCharts = new();
        public virtual IReadOnlyCollection<BloodOxygenChartEntity> BloodOxygenCharts => _bloodOxygenCharts;

        private readonly List<BloodPressureChartEntity> _bloodPressureCharts = new();
        public virtual IReadOnlyCollection<BloodPressureChartEntity> BloodPressureCharts => _bloodPressureCharts;

        private readonly List<HeartRateChartEntity> _heartRateCharts = new();
        public virtual IReadOnlyCollection<HeartRateChartEntity> HeartRateCharts => _heartRateCharts;

        private readonly List<RespitoryRateChartEntity> _respitoryRateCharts = new();
        public virtual IReadOnlyCollection<RespitoryRateChartEntity> RespitoryRateCharts => _respitoryRateCharts;

        private readonly List<TemperatureChartEntity> _temperatureCharts = new();
        public virtual IReadOnlyCollection<TemperatureChartEntity> TemperatureCharts => _temperatureCharts;

        private readonly List<PatientBedEntity> _patientBeds = new();
        public virtual IReadOnlyCollection<PatientBedEntity> PatientBeds => _patientBeds;

        private readonly List<BedEntity> _beds = new();
        public virtual IReadOnlyCollection<BedEntity> Beds => _beds;

        private readonly List<ICDCodeEntity> _icdCodes = new();
        public virtual IReadOnlyCollection<ICDCodeEntity> IcdCodes => _icdCodes;

        private readonly List<DayFeesEntity> _dayFees = new();
        public virtual IReadOnlyCollection<DayFeesEntity> DayFees => _dayFees;

        private readonly List<OralIntakeTestEntity> _oralIntakeTestRecords = new();
        public virtual IReadOnlyCollection<OralIntakeTestEntity> OralIntakeTestRecords => _oralIntakeTestRecords;

        private readonly List<OralOutputEntity> _oralOutputRecords = new();
        public virtual IReadOnlyCollection<OralOutputEntity> OralOutputRecords => _oralOutputRecords;

        private readonly List<Previous24HourIntakeEntity> _previous24HourIntakeRecords = new();
        public virtual IReadOnlyCollection<Previous24HourIntakeEntity> Previous24HourIntakeRecords => _previous24HourIntakeRecords;

        private readonly List<IVTestEntity> _ivTestRecords = new();
        public virtual IReadOnlyCollection<IVTestEntity> IvTestRecords => _ivTestRecords;

        private readonly List<IVEntity> _carePlanIVTests = new();
        public virtual IReadOnlyCollection<IVEntity> CarePlanIVTests => _carePlanIVTests;

        private readonly List<NurseCarePlanComfortSleepEntity> _comfortSleepRecords = new();
        public virtual IReadOnlyCollection<NurseCarePlanComfortSleepEntity> ComfortSleepRecords => _comfortSleepRecords;

        private readonly List<DailyCareRecordEntity> _dailyCareRecords = new();
        public virtual IReadOnlyCollection<DailyCareRecordEntity> DailyCareRecords => _dailyCareRecords;

        private readonly List<CathetherEntity> _cathetherRecords = new();
        public virtual IReadOnlyCollection<CathetherEntity> CathetherRecords => _cathetherRecords;

        private readonly List<ContinentEntity> _continentRecords = new();
        public virtual IReadOnlyCollection<ContinentEntity> ContinentRecords => _continentRecords;

        private readonly List<IVSiteEntity> _ivSiteRecords = new();
        public virtual IReadOnlyCollection<IVSiteEntity> IvSiteRecords => _ivSiteRecords;

        private readonly List<MonitorFluidEntity> _monitorFluidRecords = new();
        public virtual IReadOnlyCollection<MonitorFluidEntity> MonitorFluidRecords => _monitorFluidRecords;

        private readonly List<OralEntity> _oralRecords = new();
        public virtual IReadOnlyCollection<OralEntity> OralRecords => _oralRecords;

        private readonly List<TestTubeEntity> _testTubeRecords = new();
        public virtual IReadOnlyCollection<TestTubeEntity> TestTubeRecords => _testTubeRecords;

        private readonly List<SkinIntegrityReport> _skinIntegrityReportRecords = new();
        public virtual IReadOnlyCollection<SkinIntegrityReport> SkinIntegrityReportRecords => _skinIntegrityReportRecords;

        private readonly List<BedBathAssistEntity> _bedBathAssistRecords = new();
        public virtual IReadOnlyCollection<BedBathAssistEntity> BedBathAssistRecords => _bedBathAssistRecords;

        private readonly List<BedBathEntity> _bedBathRecords = new();
        public virtual IReadOnlyCollection<BedBathEntity> BedBathRecords => _bedBathRecords;

        private readonly List<SelfCareEntity> _selfCareRecords = new();
        public virtual IReadOnlyCollection<SelfCareEntity> SelfCareRecords => _selfCareRecords;

        private readonly List<IsolationEntity> _isolationRecords = new();
        public virtual IReadOnlyCollection<IsolationEntity> IsolationRecords => _isolationRecords;

        private readonly List<MedicationEntity> _medicationRecords = new();
        public virtual IReadOnlyCollection<MedicationEntity> MedicationRecords => _medicationRecords;

        private readonly List<PostOperativeCareEntity> _postOperativeCareRecords = new();
        public virtual IReadOnlyCollection<PostOperativeCareEntity> PostOperativeCareRecords => _postOperativeCareRecords;

        private readonly List<TractionEntity> _tractionRecords = new();
        public virtual IReadOnlyCollection<TractionEntity> TractionRecords => _tractionRecords;

        private readonly List<WoundCareEntity> _woundCareRecords = new();
        public virtual IReadOnlyCollection<WoundCareEntity> WoundCareRecords => _woundCareRecords;

        private readonly List<BedRestEntity> _bedRestRecords = new();
        public virtual IReadOnlyCollection<BedRestEntity> BedRestRecords => _bedRestRecords;

        private readonly List<ExerciseEntity> _exerciseRecords = new();
        public virtual IReadOnlyCollection<ExerciseEntity> ExerciseRecords => _exerciseRecords;

        private readonly List<MobileImmobileEntity> _mobileImmobileRecords = new();
        public virtual IReadOnlyCollection<MobileImmobileEntity> MobileImmobileRecords => _mobileImmobileRecords;

        private readonly List<WalkAssistanceEntity> _walkAssistanceRecords = new();
        public virtual IReadOnlyCollection<WalkAssistanceEntity> WalkAssistanceRecords => _walkAssistanceRecords;

        private readonly List<WalkChairEntity> _walkChairRecords = new();
        public virtual IReadOnlyCollection<WalkChairEntity> WalkChairRecords => _walkChairRecords;

        private readonly List<KeepNPOEntity> _keepNPORecords = new();
        public virtual IReadOnlyCollection<KeepNPOEntity> KeepNPORecords => _keepNPORecords;

        private readonly List<SpecialEntity> _specialRecords = new();
        public virtual IReadOnlyCollection<SpecialEntity> SpecialRecords => _specialRecords;

        private readonly List<WardDietEntity> _wardDietRecords = new();
        public virtual IReadOnlyCollection<WardDietEntity> WardDietRecords => _wardDietRecords;

        private readonly List<BloodEntity> _bloodRecords = new();
        public virtual IReadOnlyCollection<BloodEntity> BloodRecords => _bloodRecords;

        private readonly List<BloodGlucoseEntity> _bloodGlucoseRecords = new();
        public virtual IReadOnlyCollection<BloodGlucoseEntity> BloodGlucoseRecords => _bloodGlucoseRecords;

        private readonly List<NeurologicalEntity> _neurologicalRecords = new();
        public virtual IReadOnlyCollection<NeurologicalEntity> NeurologicalRecords => _neurologicalRecords;

        private readonly List<NeurovascularEntity> _neurovascularRecords = new();
        public virtual IReadOnlyCollection<NeurovascularEntity> NeurovascularRecords => _neurovascularRecords;

        private readonly List<UrineTestEntity> _urineTestRecords = new();
        public virtual IReadOnlyCollection<UrineTestEntity> UrineTestRecords => _urineTestRecords;

        private readonly List<VitalSignEntity> _vitalSignRecords = new();
        public virtual IReadOnlyCollection<VitalSignEntity> VitalSignRecords => _vitalSignRecords;

        private readonly List<InhalaNebsEntity> _inhalaNebsRecords = new();
        public virtual IReadOnlyCollection<InhalaNebsEntity> InhalaNebsRecords => _inhalaNebsRecords;

        private readonly List<MaskTimeEntity> _maskTimeRecords = new();
        public virtual IReadOnlyCollection<MaskTimeEntity> MaskTimeRecords => _maskTimeRecords;

        private readonly List<NasalCannulEntity> _nasalCannulRecords = new();
        public virtual IReadOnlyCollection<NasalCannulEntity> NasalCannulRecords => _nasalCannulRecords;

        private readonly List<PolyMaskEntity> _polyMaskRecords = new();
        public virtual IReadOnlyCollection<PolyMaskEntity> PolyMaskRecords => _polyMaskRecords;

        private readonly List<PatientProgressEntity> _patientProgressRecords = new();
        public virtual IReadOnlyCollection<PatientProgressEntity> PatientProgressRecords => _patientProgressRecords;

        private readonly List<CommunicationEntity> _communicationRecords = new();
        public virtual IReadOnlyCollection<CommunicationEntity> CommunicationRecords => _communicationRecords;

        private readonly List<HealthCareEntity> _healthCareRecords = new();
        public virtual IReadOnlyCollection<HealthCareEntity> HealthCareRecords => _healthCareRecords;

        private readonly List<SupportEntity> _supportRecords = new();
        public virtual IReadOnlyCollection<SupportEntity> SupportRecords => _supportRecords;

        private readonly List<CheckIdBandEntity> _checkIdBandRecords = new();
        public virtual IReadOnlyCollection<CheckIdBandEntity> CheckIdBandRecords => _checkIdBandRecords;

        private readonly List<CotsideEntity> _cotsideRecords = new();
        public virtual IReadOnlyCollection<CotsideEntity> CotsideRecords => _cotsideRecords;

        private readonly List<PressurePartEntity> _pressurePartRecords = new();
        public virtual IReadOnlyCollection<PressurePartEntity> PressurePartRecords => _pressurePartRecords;

        private readonly List<RednessEntity> _rednessRecords = new();
        public virtual IReadOnlyCollection<RednessEntity> RednessRecords => _rednessRecords;

        private readonly List<StoolChartEntity> _stoolChartRecords = new();
        public virtual IReadOnlyCollection<StoolChartEntity> StoolChartRecords => _stoolChartRecords;

        
    }
}