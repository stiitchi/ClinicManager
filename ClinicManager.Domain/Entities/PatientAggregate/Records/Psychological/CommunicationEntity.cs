namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological
{
    public class CommunicationEntity : EntityBase
    {
        public CommunicationEntity()
        { }
        public CommunicationEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _communicationTime = time;
            _communicationFrequency = frequency;
            _communicationSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _communicationTime;
        public DateTime CommunicationTime => _communicationTime;

        private int _communicationFrequency;
        public int CommunicationFrequency => _communicationFrequency;

        private string _communicationSignature;
        public string CommunicationSignature => _communicationSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
