using ClinicManager.Domain.Entities.UserAggregate;

namespace ClinicManager.Domain.Entities.SubscriptionAggregate
{
    public class SubscriptionEntity : EntityBase
    {
        public SubscriptionEntity()
        {}

        public SubscriptionEntity(string referenceNumber, string email, string mobileNo, string clinicName, string repFirstName, string repLastName, string clinicAddress,
                                  string postalCode, string city, string province, int amountOfNurses, string storagePlan, int pricePerNurse)
        {
            _referenceNumber    = referenceNumber;
            _email              = email;
            _mobileNo           = mobileNo;   
            _clinicName         = clinicName;
            _repFirstName       = repFirstName;
            _repLastName        = repLastName;
            _clinicAddress      = clinicAddress;
            _postalCode         = postalCode;
            _city               = city;   
            _province           = province;
            _amountOfNurses     = amountOfNurses;
            _storagePlan        = storagePlan;
            _pricePerNurse      = pricePerNurse;
            _isChecked          = false;
        }

        public void SubscriptionIsChecked()
        {
            _isChecked = true;
        }

        private string _referenceNumber;
        public string ReferenceNumber => _referenceNumber;

        private int _amountOfNurses;
        public int AmountOfNurses => _amountOfNurses;

        private int _pricePerNurse;
        public int PricePerNurse => _pricePerNurse;

        private int _overallTotal;
        public int OverallTotal => _overallTotal;

        private string _storagePlan;
        public string StoragePlan => _storagePlan;

        private string _email;
        public string Email => _email;

        private string _mobileNo;
        public string MobileNo => _mobileNo;

        private string _clinicName;
        public string ClinicName => _clinicName;

        private string _repFirstName;
        public string RepFirstName => _repFirstName;

        private string _repLastName;
        public string RepLastName => _repLastName;

        private string _clinicAddress;
        public string ClinicAddress => _clinicAddress;

        private string _postalCode;
        public string PostalCode => _postalCode;

        private string _city;
        public string City => _city;

        private string _province;
        public string Province => _province;

        private DateTime _dateScheduled;
        public DateTime DateScheduled => _dateScheduled;

        private bool _isChecked;
        public bool IsChecked => _isChecked;

        private bool _isScheduled;
        public bool IsScheduled => _isScheduled;

        private readonly List<SubscriptionCartEntity> _subscriptionCarts = new();
        public virtual IReadOnlyCollection<SubscriptionCartEntity> SubscriptionCarts => _subscriptionCarts;
    }
}
