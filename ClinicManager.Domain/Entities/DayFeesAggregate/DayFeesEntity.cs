using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.DayFeesAggregate
{
    public class DayFeesEntity : EntityBase
    {
        public DayFeesEntity()
        {
        }

        public DayFeesEntity(string dayFeeCode, string description, DateTime dateAdded)
        {
            _dayFeeCode = dayFeeCode;
            _dayFeeDescription = description;
            _dateAdded = dateAdded;
        }

        public void Set(string dayFeeCode, string description, DateTime dateAdded)
        {
            _dayFeeCode = dayFeeCode;
            _dayFeeDescription = description;
            _dateAdded = dateAdded;
        }

        private string _dayFeeCode;
        public string DayFeeCode => _dayFeeCode;

        private string _dayFeeDescription;
        public string DayFeeDescription => _dayFeeDescription;

        private DateTime _dateAdded;
        public DateTime DateAdded => _dateAdded;
    }
}
