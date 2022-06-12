namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention
{
    public class MedicationEntity : EntityBase
    {
        public MedicationEntity()
        {}

        public MedicationEntity(DateTime time, int frequency, string signature, PatientEntity patient)
        {
            _medicationTime = time;
            _medicationFrequency = frequency;
            _medicationSignature = signature;
            _patientId = patient.Id;
        }

        private DateTime _medicationTime;
        public DateTime MedicationTime => _medicationTime;

        private int _medicationFrequency;
        public int MedicationFrequency => _medicationFrequency;

        private string _medicationSignature;
        public string MedicationSignature => _medicationSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
