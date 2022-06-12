namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility
{
    public class BedRestEntity : EntityBase
    {
        public BedRestEntity()
        { }
        public BedRestEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _bedRestTime = time;
            _bedRestFrequency = frequency;
            _bedRestSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _bedRestTime;
        public DateTime BedRestTime => _bedRestTime;

        private int _bedRestFrequency;
        public int BedRestFrequency => _bedRestFrequency;

        private string _bedRestSignature;
        public string BedRestSignature => _bedRestSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
