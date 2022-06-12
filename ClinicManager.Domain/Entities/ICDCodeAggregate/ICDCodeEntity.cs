using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.ICDCodeAggregate
{
   public class ICDCodeEntity : EntityBase
    {
        public ICDCodeEntity()
        {}

        public ICDCodeEntity(string icdCode, string description, DateTime dateAdded)
        {
            _icdCode = icdCode;
            _icdDescription = description;
            _dateAdded = dateAdded;
        }

        public void Set(string icdCode, string description, DateTime dateAdded)
        {
            _icdCode = icdCode;
            _icdDescription = description;
            _dateAdded = dateAdded;
        }


        private string _icdCode;
        public string IcdCode => _icdCode;

        private string _icdDescription;
        public string IcdDescription => _icdDescription;

        private DateTime _dateAdded;
        public DateTime DateAdded => _dateAdded;
    }
}
