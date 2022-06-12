namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological
{
    public class HealthCareEntity : EntityBase
    {
        public HealthCareEntity()
        { }
        public HealthCareEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _healthEducationTime = time;
            _healthEducationFrequency = frequency;
            _healthEducationSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _healthEducationTime;
        public DateTime HealthEducationTime => _healthEducationTime;

        private int _healthEducationFrequency;
        public int HealthEducationFrequency => _healthEducationFrequency;

        private string _healthEducationSignature;
        public string HealthEducationSignature => _healthEducationSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
