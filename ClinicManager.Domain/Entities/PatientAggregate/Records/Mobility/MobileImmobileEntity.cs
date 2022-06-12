namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility
{
    public class MobileImmobileEntity : EntityBase
    {
        public MobileImmobileEntity()
        {}

        public MobileImmobileEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _mobileImmobileTime = time;
            _mobileImmobileFrequency = frequency;
            _mobileImmobileSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _mobileImmobileTime;
        public DateTime MobileImmobileTime => _mobileImmobileTime;

        private int _mobileImmobileFrequency;
        public int MobileImmobileFrequency => _mobileImmobileFrequency;

        private string _mobileImmobileSignature;
        public string MobileImmobileSignature => _mobileImmobileSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
