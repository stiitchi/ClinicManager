namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Safety
{
   public class CheckIdBandEntity : EntityBase
    {
        public CheckIdBandEntity()
        { }
        public CheckIdBandEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _checkIDBandsTime = time;
            _checkIDBandsFrequency = frequency;
            _checkIDBandsSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _checkIDBandsTime;
        public DateTime CheckIDBandsTime => _checkIDBandsTime;

        private int _checkIDBandsFrequency;
        public int CheckIDBandsFrequency => _checkIDBandsFrequency;

        private string _checkIDBandsSignature;
        public string CheckIDBandsSignature => _checkIDBandsSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
