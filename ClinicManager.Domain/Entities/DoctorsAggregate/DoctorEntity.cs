using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Domain.Entities.UserAggregate;
using ClinicManager.Domain.Entities.WardAggregate;

namespace ClinicManager.Domain.Entities.DoctorsAggregate
{
   public class DoctorEntity : EntityBase
    {
        public DoctorEntity()
        {
        }

        public DoctorEntity(string firstName, string lastName, string email, string mobileNo)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _mobileNo = mobileNo;
        }
        public void Set(string firstName, string lastName, string email, string mobileNo)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _mobileNo = mobileNo;
        }
        public void SetEmail(string email)
        {
            _email = email;
        }

        private string _email;
        public string Email => _email;

        private string _mobileNo;
        public string MobileNo => _mobileNo;

        private string _firstName;
        public string FirstName => _firstName;

        private string _lastName;
        public string LastName => _lastName;
        public WardEntity Ward { get; set; }
        public int WardId => _wardId;
        private int _wardId;
    }
}
