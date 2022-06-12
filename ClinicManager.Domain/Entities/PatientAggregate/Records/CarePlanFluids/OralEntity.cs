namespace ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanFluids
{ 
    public class OralEntity : EntityBase
    {
        public OralEntity()
        { }

        public OralEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _oralTestTime = time;
            _oralTestFrequency = frequency;
            _oralTestSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _oralTestTime;
        public DateTime OralTestTime => _oralTestTime;

        private int _oralTestFrequency;
        public int OralTestFrequency => _oralTestFrequency;

        private string _oralTestSignature;
        public string OralTestSignature => _oralTestSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
