namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Observations
{
    public class BloodEntity : EntityBase
    {
        public BloodEntity()
        { }
        public BloodEntity(DateTime time, int frequency, string signature, string recordType, PatientEntity patient)
        {
            _bloodTime = time;
            _bloodFrequency = frequency;
            _bloodSignature = signature;
            _recordType = recordType;
            _patientId = patient.Id;
        }

        private DateTime _bloodTime;
        public DateTime BloodTime => _bloodTime;

        private int _bloodFrequency;
        public int BloodFrequency => _bloodFrequency;

        private string _bloodSignature;
        public string BloodSignature => _bloodSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
