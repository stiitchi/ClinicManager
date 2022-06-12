namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene
{ 
    public class BedBathAssistEntity : EntityBase
    {
        public BedBathAssistEntity()
        { }

        public BedBathAssistEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _bedBathAssistTime = time;
            _bedBathAssistFrequency = frequency;
            _bedBathAssistSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _bedBathAssistTime;
        public DateTime BedBathAssistTime => _bedBathAssistTime;

        private int _bedBathAssistFrequency;
        public int BedBathAssistFrequency => _bedBathAssistFrequency;

        private string _bedBathAssistSignature;
        public string BedBathAssistSignature => _bedBathAssistSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
