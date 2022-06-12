namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation
{
    public class MaskTimeEntity : EntityBase
    {
        public MaskTimeEntity()
        { }
        public MaskTimeEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _maskTime = time;
            _maskFrequency = frequency;
            _maskSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _maskTime;
        public DateTime MaskTime => _maskTime;

        private int _maskFrequency;
        public int MaskFrequency => _maskFrequency;

        private string _maskSignature;
        public string MaskSignature => _maskSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
