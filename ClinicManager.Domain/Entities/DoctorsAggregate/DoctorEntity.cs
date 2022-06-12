using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Domain.Entities.UserAggregate;

namespace ClinicManager.Domain.Entities.DoctorsAggregate
{
   public class DoctorEntity : EntityBase
    {
        public DoctorEntity()
        {
        }

        public DoctorEntity(PatientEntity patient, UserEntity doctor, RoleEntity role)
        {
            _patientId = patient.Id;
            _doctorId = doctor.Id;
            _roleId = role.Id;
        }
        public void Set(PatientEntity patient, UserEntity doctor, RoleEntity role)
        {
            _patientId = patient.Id;
            _doctorId = doctor.Id;
            _roleId = role.Id;
        }

        public UserEntity Doctor { get; set; }
        public int DoctorId => _doctorId;
        private int _doctorId;
        public RoleEntity Role { get; set; }
        public int RoleId => _roleId;
        private int _roleId;
        public PatientEntity Patient { get; set; }
        public int PatientId => _patientId;
        private int _patientId;
    }
}
