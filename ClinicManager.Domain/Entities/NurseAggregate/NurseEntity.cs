using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Domain.Entities.UserAggregate;

namespace ClinicManager.Domain.Entities.NurseAggregate
{
     public class NurseEntity : EntityBase
    {
        public NurseEntity()
        {
        }

        public NurseEntity(PatientEntity patient, UserEntity nurse, RoleEntity role)
        {
            _patientId = patient.Id;
            _nurseId = nurse.Id;
            _roleId = role.Id;
        }
        public void Set(PatientEntity patient, UserEntity nurse, RoleEntity role)
        {
            _patientId = patient.Id;
            _nurseId = nurse.Id;
            _roleId = role.Id;
        }

        public UserEntity Nurse { get; set; }
        public int NurseId => _nurseId;
        private int _nurseId;
        public RoleEntity Role { get; set; }
        public int RoleId => _roleId;
        private int _roleId;
        public PatientEntity Patient { get; set; }
        public int PatientId => _patientId;
        private int _patientId;
    }
}
