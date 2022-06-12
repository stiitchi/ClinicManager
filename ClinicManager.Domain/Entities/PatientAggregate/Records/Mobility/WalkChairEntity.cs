namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility
{
    public class WalkChairEntity : EntityBase
    {
        public WalkChairEntity()
        {}

        public WalkChairEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _assistIntoChairTime = time;
            _assistIntoChairFrequency = frequency;
            _assistIntoChairSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _assistIntoChairTime;
        public DateTime AssistIntoChairTime => _assistIntoChairTime;

        private int _assistIntoChairFrequency;
        public int AssistIntoChairFrequency => _assistIntoChairFrequency;

        private string _assistIntoChairSignature;
        public string AssistIntoChairSignature => _assistIntoChairSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
