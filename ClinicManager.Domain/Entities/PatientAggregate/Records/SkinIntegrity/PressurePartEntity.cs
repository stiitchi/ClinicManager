namespace ClinicManager.Domain.Entities.PatientAggregate.Records.SkinIntegrity
{
    public class PressurePartEntity : EntityBase
    {
        public PressurePartEntity()
        { }
        public PressurePartEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _pressurePartCareTime = time;
            _pressurePartCareFrequency = frequency;
            _pressurePartCareSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _pressurePartCareTime;
        public DateTime PressurePartCareTime => _pressurePartCareTime;

        private int _pressurePartCareFrequency;
        public int PressurePartCareFrequency => _pressurePartCareFrequency;

        private string _pressurePartCareSignature;
        public string PressurePartCareSignature => _pressurePartCareSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
