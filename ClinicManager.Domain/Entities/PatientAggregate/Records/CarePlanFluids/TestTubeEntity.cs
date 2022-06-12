namespace ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanFluids
{
    public class TestTubeEntity : EntityBase
    {
        public TestTubeEntity()
        {}
        public TestTubeEntity(TimeSpan time, int frequency, string signature, PatientEntity patient)
        {
            _tubeTestTime = time;
            _tubeTestFrequency = frequency;
            _tubeTestSignature = signature;
            _patientId = patient.Id;
        }

        private TimeSpan _tubeTestTime;
        public TimeSpan TubeTestTime => _tubeTestTime;

        private int _tubeTestFrequency;
        public int TubeTestFrequency => _tubeTestFrequency;

        private string _tubeTestSignature;
        public string TubeTestSignature => _tubeTestSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
