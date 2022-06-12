namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Safety
{
    public class CotsideEntity : EntityBase
    {
        public CotsideEntity()
        { }
        public CotsideEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _cotsidesTime = time;
            _cotsidesFrequency = frequency;
            _cotsidesSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _cotsidesTime;
        public DateTime CotsidesTime => _cotsidesTime;

        private int _cotsidesFrequency;
        public int CotsidesFrequency => _cotsidesFrequency;

        private string _cotsidesSignature;
        public string CotsidesSignature => _cotsidesSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
