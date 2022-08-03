using ClinicManager.Domain.Entities.BedAggregate;
using ClinicManager.Domain.Entities.DayFeesAggregate;
using ClinicManager.Domain.Entities.FaultAggregate;
using ClinicManager.Domain.Entities.ICDCodeAggregate;
using ClinicManager.Domain.Entities.NotificationAggregate;
using ClinicManager.Domain.Entities.WardAggregate;

namespace ClinicManager.Domain.Entities.UserAggregate
{
    public class UserEntity : EntityBase
    {
        public UserEntity()
        {
        }


        public UserEntity(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public UserEntity(string firstName, string lastName, string mobileNo)
        {
            _firstName = firstName;
            _lastName = lastName;
            _mobileNo = mobileNo;
        }
        public UserEntity(string firstName, string lastName, string email, string mobileNo)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _mobileNo = mobileNo; 
        }
        public void Set(string firstName, string lastName, string mobileNo)
        {
            _firstName = firstName;
            _lastName = lastName;
            _mobileNo = mobileNo;
        }
 
        public void SetPasswordReset(string token, DateTime expiryDate)
        {
            _passwordResetToken = token;
            _passwordResetTokenExpiry = expiryDate;
        }

        public void SetPassword(byte[] passwordHash, byte[] passwordSalt)
        {
            _passwordHash = passwordHash;
            _passwordSalt = passwordSalt;
        }
        public void AddUserRole(UserRolesEntity userRolesEntity)
        {
            _userRoles.Add(userRolesEntity);
        }

        public void SetAsLoggedIn()
        {
            _isLoggedIn = true;
        }

        public void SetAsLoggedOut()
        {
            _isLoggedIn = false;
        }

        public void SetRole(string role)
        {
            _role = role;
        }
        public void ConfirmEmail()
        {
            _emailConfirmed = true;
        }

        public void SetEmail(string email)
        {
            _email = email;
        }

        public void SetActivationToken(string token)
        {
            _activationToken = token;
        }

        public void AssignDoctorToPatient(int doctorId, int patientId)
        {
            _doctorId = doctorId;
            _patientId = patientId;
        }
        public void AssignNurseToPatient(int nurseId, int patientId)
        {
            _nurseId = nurseId;
            _patientId = patientId;
        }

        private bool _isLoggedIn;
        public bool IsLoggedIn => _isLoggedIn;

        private int _patientId;
        public int PatientId => _patientId;

        private int _wardId;
        public int WardId => _wardId;

        private int _doctorId;
        public int DoctorId => _doctorId;

        private int _nurseId;
        public int NurseId => _nurseId;

        private string _role;
        public string Role => _role;

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

        private readonly List<UserRolesEntity> _userRoles = new();
        public virtual IReadOnlyCollection<UserRolesEntity> UserRoles => _userRoles;

        private readonly List<BedEntity> _beds = new();
        public virtual IReadOnlyCollection<BedEntity> Beds => _beds;

        private readonly List<WardEntity> _wards = new();
        public virtual IReadOnlyCollection<WardEntity> Wards => _wards;

        private readonly List<DayFeesEntity> _dayFees = new();
        public virtual IReadOnlyCollection<DayFeesEntity> DayFees => _dayFees;

        private readonly List<ICDCodeEntity> _icdCodes = new();
        public virtual IReadOnlyCollection<ICDCodeEntity> ICDCodes => _icdCodes;

        private readonly List<NotificationEntity> _notifications = new();
        public virtual IReadOnlyCollection<NotificationEntity> Notifications => _notifications;

        private readonly List<FaultEntity> _faults = new();
        public virtual IReadOnlyCollection<FaultEntity> Faults => _faults;

    }
}
