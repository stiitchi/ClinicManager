namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Observations
{
    public class NeurologicalEntity : EntityBase
    {
        public NeurologicalEntity()
        { }
        public NeurologicalEntity(DateTime time, int frequency, string signature, string recordType, PatientEntity patient)
        {
            _neuroLogicalTime = time;
            _neuroLogicalFrequency = frequency;
            _neuroLogicalSignature = signature;
            _recordType = recordType;
            _patientId = patient.Id;
        }

        private DateTime _neuroLogicalTime;
        public DateTime NeuroLogicalTime => _neuroLogicalTime;

        private int _neuroLogicalFrequency;
        public int NeuroLogicalFrequency => _neuroLogicalFrequency;

        private string _neuroLogicalSignature;
        public string NeuroLogicalSignature => _neuroLogicalSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
