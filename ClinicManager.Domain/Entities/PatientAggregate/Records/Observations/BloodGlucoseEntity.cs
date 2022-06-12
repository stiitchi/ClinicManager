namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Observations
{
     public class BloodGlucoseEntity : EntityBase
    {
        public BloodGlucoseEntity()
        { }
        public BloodGlucoseEntity(DateTime time, int frequency, string signature, string recordType, PatientEntity patient)
        {
            _bloodGlucoseTime = time;
            _bloodGlucoseFrequency = frequency;
            _bloodGlucoseSignature = signature;
            _recordType = recordType;
            _patientId = patient.Id;
        }

        private DateTime _bloodGlucoseTime;
        public DateTime BloodGlucoseTime => _bloodGlucoseTime;

        private int _bloodGlucoseFrequency;
        public int BloodGlucoseFrequency => _bloodGlucoseFrequency;

        private string _bloodGlucoseSignature;
        public string BloodGlucoseSignature => _bloodGlucoseSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
