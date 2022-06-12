namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition
{ 
    public class SpecialEntity : EntityBase
    {
        public SpecialEntity()
        { }
        public SpecialEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _specialTime = time;
            _specialFrequency = frequency;
            _specialSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _specialTime;
        public DateTime SpecialTime => _specialTime;

        private int _specialFrequency;
        public int SpecialFrequency => _specialFrequency;

        private string _specialSignature;
        public string SpecialSignature => _specialSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
