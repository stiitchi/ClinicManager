using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.BedAggregate
{
    public class PatientBedEntity : EntityBase
    {
        public PatientBedEntity()
        {
        }

        public PatientBedEntity(string patientName, PatientEntity patient, BedEntity bed)
        {
            _patientName = patientName;
            _patientId = patient.Id;
            _bedId = bed.Id;
        }
        public void Set(string patientName, PatientEntity patient, BedEntity bed)
        {
            _patientName = patientName;
            _patientId = patient.Id;
            _bedId = bed.Id;
        }

        public string PatientName => _patientName;
        private string _patientName;
        public BedEntity Bed { get; set; }
        public int BedId => _bedId;
        private int _bedId;
        public PatientEntity Patient { get; set; }
        public int PatientId => _patientId;
        private int _patientId;
    }
}
