using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Domain.Entities.UserAggregate;
using ClinicManager.Domain.Entities.WardAggregate;

namespace ClinicManager.Domain.Entities.BedAggregate
{
    public class BedEntity : EntityBase
    {
        public BedEntity()
        {}
        public BedEntity(int bedNumber, string wardNumber, WardEntity ward)
        {
            _bedNumber = bedNumber;
            _wardNumber = wardNumber;
            _wardId = ward.Id;
        }
        public BedEntity(int bedId, int bedNumber, string wardNumber, WardEntity ward)
        {
            _id = bedId;
            _bedNumber = bedNumber;
            _wardNumber = wardNumber;
            _wardId = ward.Id;
        }
        public void Set(int bedNumber, string wardNumber, WardEntity ward)
        {
            _bedNumber = bedNumber;
            _wardNumber = wardNumber;
            _wardId = ward.Id;
        }

        public void AssignPatientToBed(PatientEntity patient)
        {
            _patientId = patient.Id;
        }

        public void AssignNurseToBed(int nurseId)
        {
            _nurseId = nurseId;
        }

        private int _bedNumber;
        public int BedNumber => _bedNumber;

        private string _wardNumber;
        public string WardNumber => _wardNumber;

        public WardEntity Ward;
        private int _wardId;
        public int WardId => _wardId;

        public PatientEntity Patient;
        private int? _patientId;
        public int? PatientId => _patientId;

        public UserEntity Nurse;

        private int? _nurseId;
        public int? NurseId => _nurseId;

        private readonly List<PatientBedEntity> _patientBeds = new();
        public virtual IReadOnlyCollection<PatientBedEntity> PatientBeds => _patientBeds;

    }
}
