using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Domain.Entities.WardAggregate;

namespace ClinicManager.Domain.Entities.BedAggregate
{
    public class PatientBedEntity : EntityBase
    {
        public PatientBedEntity()
        {
        }

        public PatientBedEntity(PatientEntity patient, WardEntity ward, BedEntity bed)
        {
            _patientId = patient.Id;
            _wardId = ward.Id;
            _bedId = bed.Id;
        }
        public void Set(PatientEntity patient, WardEntity ward, BedEntity bed)
        {
            _patientId = patient.Id;
            _wardId = ward.Id;
            _bedId = bed.Id;
        }
        public BedEntity Bed { get; set; }
        public int BedId => _bedId;
        private int _bedId;
        public WardEntity Ward { get; set; }
        public int WardId => _wardId;
        private int _wardId;
        public PatientEntity Patient { get; set; }
        public int PatientId => _patientId;
        private int _patientId;
    }
}
