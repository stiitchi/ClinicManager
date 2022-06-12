namespace ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanFluids
{
    public class IVEntity : EntityBase
    {
        public IVEntity()
        {}

        public IVEntity(TimeSpan time, int frequency, string signature, PatientEntity patient)
        {
            _ivTestTime = time;
            _ivTestFrequency = frequency;
            _ivTestSignature = signature;
        }

        private TimeSpan _ivTestTime;
        public TimeSpan IvTestTime => _ivTestTime;

        private int _ivTestFrequency;
        public int IvTestFrequency => _ivTestFrequency;

        private string _ivTestSignature;
        public string IvTestSignature => _ivTestSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
