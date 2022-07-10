using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Domain.Entities.UserAggregate;

namespace ClinicManager.Domain.Entities.NurseAggregate
{
     public class NurseEntity : EntityBase
    {
        public NurseEntity()
        {
        }

        public NurseEntity(UserEntity nurse, RoleEntity role, string firstName, string lastName, string email, string mobileNo)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _mobileNo = mobileNo;
            _nurseId = nurse.Id;
            _roleId = role.Id;
        }


        public void AssignNurseToPatient(PatientEntity patient)
        {
            _patientId = patient.Id;
        }

        private string _email;
        public string Email => _email;

        private string _mobileNo;
        public string MobileNo => _mobileNo;

        private string _password;
        public string Password => Password;

        private string _firstName;
        public string FirstName => _firstName;

        private string _lastName;
        public string LastName => _lastName;

        private byte[] _passwordHash;
        public byte[] PasswordHash => _passwordHash;

        private byte[] _passwordSalt;
        public byte[] PasswordSalt => _passwordSalt;

        private string _passwordResetToken;
        public string PasswordResetToken => _passwordResetToken;

        private DateTime? _passwordResetTokenExpiry;
        public DateTime? PasswordResetTokenExpiry => _passwordResetTokenExpiry;

        private bool _emailConfirmed;
        public bool EmailConfirmed => _emailConfirmed;

        private string _activationToken;
        public string ActivationToken => _activationToken;
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
