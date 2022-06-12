namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene
{
    public class BedBathEntity : EntityBase
    {
        public BedBathEntity()
        {}

        public BedBathEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _bedBathTime = time;
            _bedBathFrequency = frequency;
            _bedBathSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _bedBathTime;
        public DateTime BedBathTime => _bedBathTime;

        private int _bedBathFrequency;
        public int BedBathFrequency => _bedBathFrequency;

        private string _bedBathSignature;
        public string BedBathSignature => _bedBathSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
