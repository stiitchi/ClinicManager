namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological
{
    public class SupportEntity : EntityBase
    {
        public SupportEntity()
        { }
        public SupportEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _supportTime = time;
            _supportFrequency = frequency;
            _supportSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _supportTime;
        public DateTime SupportTime => _supportTime;

        private int _supportFrequency;
        public int SupportFrequency => _supportFrequency;

        private string _supportSignature;
        public string SupportSignature => _supportSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
