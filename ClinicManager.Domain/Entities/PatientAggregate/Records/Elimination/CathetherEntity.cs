namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Elimination
{
    public class CathetherEntity : EntityBase
    {
        public CathetherEntity()
        {}

        public CathetherEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _cathetherTime = time;
            _cathetherFrequency = frequency;
            _cathetherSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _cathetherTime;
        public DateTime CathetherTime => _cathetherTime;

        private int _cathetherFrequency;
        public int CathetherFrequency => _cathetherFrequency;

        private string _cathetherSignature;
        public string CathetherSignature => _cathetherSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}

