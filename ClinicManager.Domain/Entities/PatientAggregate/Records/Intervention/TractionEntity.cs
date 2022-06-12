namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention
{
    public class TractionEntity : EntityBase
    {
        public TractionEntity()
        { }
        public TractionEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _tractionTime = time;
            _tractionFrequency = frequency;
            _tractionSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _tractionTime;
        public DateTime TractionTime => _tractionTime;

        private int _tractionFrequency;
        public int TractionFrequency => _tractionFrequency;

        private string _tractionSignature;
        public string TractionSignature => _tractionSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
