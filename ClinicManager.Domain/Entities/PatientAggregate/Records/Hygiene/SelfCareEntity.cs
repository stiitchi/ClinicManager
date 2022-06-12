namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene
{
    public class SelfCareEntity : EntityBase
    {
        public SelfCareEntity()
        { }
        public SelfCareEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _selfCareTime = time;
            _selfCareFrequency = frequency;
            _selfCareSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _selfCareTime;
        public DateTime SelfCareTime => _selfCareTime;

        private int _selfCareFrequency;
        public int SelfCareFrequency => _selfCareFrequency;

        private string _selfCareSignature;
        public string SelfCareSignature => _selfCareSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
