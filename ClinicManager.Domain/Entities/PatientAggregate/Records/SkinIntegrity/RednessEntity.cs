namespace ClinicManager.Domain.Entities.PatientAggregate.Records.SkinIntegrity
{
    public class RednessEntity : EntityBase
    {
        public RednessEntity()
        { }
        public RednessEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _reportRednessTime = time;
            _reportRednessFrequency = frequency;
            _reportRednessSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _reportRednessTime;
        public DateTime ReportRednessTime => _reportRednessTime;

        private int _reportRednessFrequency;
        public int ReportRednessFrequency => _reportRednessFrequency;

        private string _reportRednessSignature;
        public string ReportRednessSignature => _reportRednessSignature;

        private string _recordType;
        public string RecordType => _recordType;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
