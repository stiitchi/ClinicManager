namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition
{
    public class KeepNPOEntity : EntityBase
    {
        public KeepNPOEntity()
        { }
        public KeepNPOEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _keepNPOTime = time;
            _keepNPOFrequency = frequency;
            _keepNPOSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _keepNPOTime;
        public DateTime KeepNPOTime => _keepNPOTime;

        private int _keepNPOFrequency;
        public int KeepNPOFrequency => _keepNPOFrequency;

        private string _keepNPOSignature;
        public string KeepNPOSignature => _keepNPOSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
