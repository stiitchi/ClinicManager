namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention
{
    public class PostOperativeCareEntity : EntityBase
    {
        public PostOperativeCareEntity()
        { }
        public PostOperativeCareEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _postOperativeCareTime = time;
            _postOperativeCareFrequency = frequency;
            _postOperativeCareSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _postOperativeCareTime;
        public DateTime PostOperativeCareTime => _postOperativeCareTime;

        private int _postOperativeCareFrequency;
        public int PostOperativeCareFrequency => _postOperativeCareFrequency;

        private string _postOperativeCareSignature;
        public string PostOperativeCareSignature => _postOperativeCareSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
