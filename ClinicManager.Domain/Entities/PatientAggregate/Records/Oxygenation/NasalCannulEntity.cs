namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation
{
    public class NasalCannulEntity : EntityBase
    {
        public NasalCannulEntity()
        { }
        public NasalCannulEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _nasalCannulaTime = time;
            _nasalCannulaFrequency = frequency;
            _nasalCannulaSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _nasalCannulaTime;
        public DateTime NasalCannulaTime => _nasalCannulaTime;

        private int _nasalCannulaFrequency;
        public int NasalCannulaFrequency => _nasalCannulaFrequency;

        private string _nasalCannulaSignature;
        public string NasalCannulaSignature => _nasalCannulaSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
