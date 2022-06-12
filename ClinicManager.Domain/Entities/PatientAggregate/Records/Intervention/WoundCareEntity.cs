namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention
{
    public class WoundCareEntity : EntityBase
    {
        public WoundCareEntity()
        { }
        public WoundCareEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _woundCareTime = time;
            _woundCareFrequency = frequency;
            _woundCareSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _woundCareTime;
        public DateTime WoundCareTime => _woundCareTime;

        private int _woundCareFrequency;
        public int WoundCareFrequency => _woundCareFrequency;

        private string _woundCareSignature;
        public string WoundCareSignature => _woundCareSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
