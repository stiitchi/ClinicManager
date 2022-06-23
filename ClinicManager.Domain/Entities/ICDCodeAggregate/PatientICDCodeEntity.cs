using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.ICDCodeAggregate
{
    public class PatientICDCodeEntity : EntityBase
    {
        public PatientICDCodeEntity()
        {
        }

        public PatientICDCodeEntity(PatientEntity patient, ICDCodeEntity ICD, string icdCode, string icdDescription)
        {
            _patientId = patient.Id;
            _icdCodeId = ICD.Id;
            _icdCode = icdCode;
            _icdDescription = icdDescription;
        }
        public void Set(PatientEntity patient, ICDCodeEntity ICD, string icdCode, string icdDescription)
        {
            _patientId = patient.Id;
            _icdCodeId = ICD.Id;
            _icdCode = icdCode;
            _icdDescription = icdDescription;
        }

        private string _icdCode;
        public string IcdCode => _icdCode;

        private string _icdDescription;
        public string IcdDescription => _icdDescription;
        public ICDCodeEntity ICDCode { get; set; }
        public int IcdCodeId => _icdCodeId;
        private int _icdCodeId;
        public PatientEntity Patient { get; set; }
        public int PatientId => _patientId;
        private int _patientId;
    }
}
