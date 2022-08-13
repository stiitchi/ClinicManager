namespace ClinicManager.Domain.Entities.PatientAggregate.Allergies
{
    public class PatientAllergiesEntity : EntityBase
    {
        public PatientAllergiesEntity()
        { }

        public PatientAllergiesEntity(string description, PatientEntity patient)
        {
            _description = description;
            _patientId = patient.Id;
        }

        public void Set(string description, PatientEntity patient)
        {
            _description = description;
            _patientId = patient.Id;
        }

        private string _description;
        public string Description => _description;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
