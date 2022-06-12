namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition
{
   public class WardDietEntity : EntityBase
    {
        public WardDietEntity()
        { }
        public WardDietEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _fullWardDietTime = time;
            _fullWardDietFrequency = frequency;
            _fullWardDietSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _fullWardDietTime;
        public DateTime FullWardDietTime => _fullWardDietTime;

        private int _fullWardDietFrequency;
        public int FullWardDietFrequency => _fullWardDietFrequency;

        private string _fullWardDietSignature;
        public string FullWardDietSignature => _fullWardDietSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
