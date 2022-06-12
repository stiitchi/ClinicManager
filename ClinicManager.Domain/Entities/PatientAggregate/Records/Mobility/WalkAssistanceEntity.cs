namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility
{
  public class WalkAssistanceEntity : EntityBase
    {
        public WalkAssistanceEntity()
        { }
        public WalkAssistanceEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _walkWithAssistanceTime = time;
            _walkWithAssistanceFrequency = frequency;
            _walkWithAssistanceSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _walkWithAssistanceTime;
        public DateTime WalkWithAssistanceTime => _walkWithAssistanceTime;

        private int _walkWithAssistanceFrequency;
        public int WalkWithAssistanceFrequency => _walkWithAssistanceFrequency;

        private string _walkWithAssistanceSignature;
        public string WalkWithAssistanceSignature => _walkWithAssistanceSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
