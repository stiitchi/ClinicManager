namespace ClinicManager.Domain.Entities.PatientAggregate.Problems
{
    public class PatientProblemsEntity : EntityBase
    {
        public PatientProblemsEntity()
        { }

        public PatientProblemsEntity(string description, DateTime onSetDate, PatientEntity patient)
        {
            _description = description;
            _onSetDate = onSetDate;
            _patientId = patient.Id;
        }

        public void Set(string description, DateTime onSetDate, PatientEntity patient)
        {
            _description = description;
            _onSetDate = onSetDate;
            _patientId = patient.Id;
        }

        private string _description;
        public string Description => _description;

        private DateTime _onSetDate;
        public DateTime OnSetDate => _onSetDate;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
