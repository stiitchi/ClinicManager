using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Domain.Entities.UserAggregate;

namespace ClinicManager.Domain.Entities.NurseAggregate
{
   public class PatientNurseEntity : EntityBase
    {
        public PatientNurseEntity()
        {
        }

        public PatientNurseEntity(PatientEntity patient, UserEntity nurse)
        {
            _patientId = patient.Id;
            _nurseId = nurse.Id;
        }
        public void Set(PatientEntity patient, UserEntity nurse)
        {
            _patientId = patient.Id;
            _nurseId = nurse.Id;
        }

        public UserEntity Nurse { get; set; }
        public int NurseId => _nurseId;
        private int _nurseId;
        public PatientEntity Patient { get; set; }
        public int PatientId => _patientId;
        private int _patientId;
    }
}
