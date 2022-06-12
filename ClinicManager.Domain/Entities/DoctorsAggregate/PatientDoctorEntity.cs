using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Domain.Entities.UserAggregate;

namespace ClinicManager.Domain.Entities.DoctorsAggregate
{
      public class PatientDoctorEntity : EntityBase
    {
        public PatientDoctorEntity()
        {
        }

        public PatientDoctorEntity(PatientEntity patient, UserEntity doctor)
        {
            _patientId = patient.Id;
            _doctorId = doctor.Id;
        }
        public void Set(PatientEntity patient, UserEntity doctor)
        {
            _patientId = patient.Id;
            _doctorId = doctor.Id;
        }

        public UserEntity Doctor { get; set; }
        public int DoctorId => _doctorId;
        private int _doctorId;
        public PatientEntity Patient { get; set; }
        public int PatientId => _patientId;
        private int _patientId;
    }
}
