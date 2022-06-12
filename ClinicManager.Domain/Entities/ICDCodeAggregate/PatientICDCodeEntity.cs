using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.ICDCodeAggregate
{
    public class PatientICDCodeEntity : EntityBase
    {
        public PatientICDCodeEntity()
        {
        }

        public PatientICDCodeEntity(PatientEntity patient, ICDCodeEntity ICD)
        {
            _patientId = patient.Id;
            _icdCodeId = ICD.Id;
        }
        public void Set(PatientEntity patient, ICDCodeEntity ICD)
        {
            _patientId = patient.Id;
            _icdCodeId = ICD.Id;
        }
        public ICDCodeEntity ICDCode { get; set; }
        public int IcdCodeId => _icdCodeId;
        private int _icdCodeId;
        public PatientEntity Patient { get; set; }
        public int PatientId => _patientId;
        private int _patientId;
    }
}
