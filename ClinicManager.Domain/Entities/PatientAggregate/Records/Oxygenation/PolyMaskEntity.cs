namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation
{
    public class PolyMaskEntity : EntityBase
    {
        public PolyMaskEntity()
        { }
        public PolyMaskEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _polyMaskTime = time;
            _polyMaskFrequency = frequency;
            _polyMaskSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _polyMaskTime;
        public DateTime PolyMaskTime => _polyMaskTime;

        private int _polyMaskFrequency;
        public int PolyMaskFrequency => _polyMaskFrequency;

        private string _polyMaskSignature;
        public string PolyMaskSignature => _polyMaskSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
