namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility
{
    public class ExerciseEntity : EntityBase
    {
        public ExerciseEntity()
        { }
        public ExerciseEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _exercisesTime = time;
            _exercisesFrequency = frequency;
            _exercisesSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _exercisesTime;
        public DateTime ExercisesTime => _exercisesTime;

        private int _exercisesFrequency;
        public int ExercisesFrequency => _exercisesFrequency;

        private string _exercisesSignature;
        public string ExercisesSignature => _exercisesSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}