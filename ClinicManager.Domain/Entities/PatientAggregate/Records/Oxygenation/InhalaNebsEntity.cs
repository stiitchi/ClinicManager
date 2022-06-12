namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation
{
    public class InhalaNebsEntity : EntityBase
    {
        public InhalaNebsEntity()
        { }
        public InhalaNebsEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _inhalaNebsTime = time;
            _inhalaNebsFrequency = frequency;
            _inhalaNebsSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _inhalaNebsTime;
        public DateTime InhalaNebsTime => _inhalaNebsTime;

        private int _inhalaNebsFrequency;
        public int InhalaNebsFrequency => _inhalaNebsFrequency;

        private string _inhalaNebsSignature;
        public string InhalaNebsSignature => _inhalaNebsSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
