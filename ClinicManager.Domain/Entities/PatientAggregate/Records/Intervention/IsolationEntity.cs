namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention
{
    public class IsolationEntity : EntityBase
    {
        public IsolationEntity()
        { }

        public IsolationEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _isolationTime = time;
            _isolationFrequency = frequency;
            _isolationSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _isolationTime;
        public DateTime IsolationTime => _isolationTime;

        private int _isolationFrequency;
        public int IsolationFrequency => _isolationFrequency;

        private string _isolationSignature;
        public string IsolationSignature => _isolationSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
