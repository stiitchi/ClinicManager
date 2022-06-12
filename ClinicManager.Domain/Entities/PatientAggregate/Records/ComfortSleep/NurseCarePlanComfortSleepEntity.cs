
namespace ClinicManager.Domain.Entities.PatientAggregate.Records.ComfortSleep
{
    public class NurseCarePlanComfortSleepEntity : EntityBase
    {
        public NurseCarePlanComfortSleepEntity()
        { }

        public NurseCarePlanComfortSleepEntity(DateTime painControlTime, int painControlFrequency, string signature, PatientEntity patient)
        {
            _painControlTime = painControlTime;
            _painControlFrequency = painControlFrequency;
            _painControlSignature = signature;
            _patientId = patient.Id;
        }
        public void Set(DateTime painControlTime, int painControlFrequency, string signature, PatientEntity patient)
        {
            _painControlTime = painControlTime;
            _painControlFrequency = painControlFrequency;
            _painControlSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _painControlTime;
        public DateTime PainControlTime => _painControlTime;

        private int _painControlFrequency;
        public int PainControlFrequency => _painControlFrequency;

        private string _painControlSignature;
        public string PainControlSignature => _painControlSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;

    }
}
