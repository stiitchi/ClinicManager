namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Observations
{
    public class UrineTestEntity : EntityBase
    {
        public UrineTestEntity()
        { }
        public UrineTestEntity(DateTime time, int frequency, string signature, string recordType, PatientEntity patient)
        {
            _urineTestTime = time;
            _urineTestFrequency = frequency;
            _urineTestSignature = signature;
            _recordType = recordType;
            _patientId = patient.Id;
        }

        private DateTime _urineTestTime;
        public DateTime UrineTestTime => _urineTestTime;

        private int _urineTestFrequency;
        public int UrineTestFrequency => _urineTestFrequency;

        private string _urineTestSignature;
        public string UrineTestSignature => _urineTestSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
