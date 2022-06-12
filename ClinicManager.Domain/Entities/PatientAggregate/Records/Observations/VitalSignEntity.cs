namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Observations
{
    public class VitalSignEntity : EntityBase
    {
        public VitalSignEntity()
        { }
        public VitalSignEntity(DateTime time, int frequency, string signature, string recordType, PatientEntity patient)
        {
            _vitalSignsTime = time;
            _vitalSignsFrequency = frequency;
            _vitalSignSignature = signature;
            _recordType = recordType;
            _patientId = patient.Id;
        }

        private DateTime _vitalSignsTime;
        public DateTime VitalSignsTime => _vitalSignsTime;

        private int _vitalSignsFrequency;
        public int VitalSignsFrequency => _vitalSignsFrequency;

        private string _vitalSignSignature;
        public string VitalSignSignature => _vitalSignSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
