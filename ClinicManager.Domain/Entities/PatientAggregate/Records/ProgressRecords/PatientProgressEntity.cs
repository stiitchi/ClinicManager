
namespace ClinicManager.Domain.Entities.PatientAggregate.Records.ProgressRecords
{
    public class PatientProgressEntity : EntityBase
    {
        public PatientProgressEntity()
        {}

        public PatientProgressEntity(string allergy, string desc, string riskFactor, 
                DateTime dateAdded, DateTime timeAdded, PatientEntity patient)
        {
            _allergy = allergy;
            _description = desc;
            _riskFactor = riskFactor;
            _dateAdded = dateAdded;
            _timeAdded = timeAdded;
            _patientId = patient.Id;
        }

        public void Set(string allergy, string desc, string riskFactor,
              DateTime dateAdded, DateTime timeAdded, PatientEntity patient)
        {
            _allergy = allergy;
            _description = desc;
            _riskFactor = riskFactor;
            _dateAdded = dateAdded;
            _timeAdded = timeAdded;
            _patientId = patient.Id;
        }

        private string _allergy;
        public string Allergy => _allergy;

        private string _description;
        public string Description => _description;

        private string _riskFactor;
        public string RiskFactor => _riskFactor;

        private DateTime _dateAdded;
        public DateTime DateAdded => _dateAdded;

        private DateTime _timeAdded;
        public DateTime TimeAdded => _timeAdded;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
