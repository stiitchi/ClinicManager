namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Elimination
{
    public class ContinentEntity : EntityBase
    {
        public ContinentEntity()
        {}

        public ContinentEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _continentTime = time;
            _continentFrequency = frequency;
            _continentSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _continentTime;
        public DateTime ContinentTime => _continentTime;

        private int _continentFrequency;
        public int ContinentFrequency => _continentFrequency;

        private string _continentSignature;
        public string ContinentSignature => _continentSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
