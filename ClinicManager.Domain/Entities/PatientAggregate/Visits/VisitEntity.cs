using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.PatientAggregate.Visits
{
    public class VisitEntity : EntityBase
    {
        public VisitEntity()
        { }

        public VisitEntity(DateTime startDate, DateTime endDate, string problemDescription, string address, string city, string postalCode, string province, PatientEntity patient)
        {
            _startDate = startDate;
            _endDate = endDate;
            _problemDescription = problemDescription;
            _address = address;
            _city = city;
            _postalCode = postalCode;
            _province = province;
            _patientId = patient.Id;
        }

        public void Set(DateTime startDate, DateTime endDate, string problemDescription, string address, string city, string postalCode, string province, PatientEntity patient)
        {
            _startDate = startDate;
            _endDate = endDate;
            _problemDescription = problemDescription;
            _address = address;
            _city = city;
            _postalCode = postalCode;
            _province = province;
            _patientId = patient.Id;
        }

        private DateTime _startDate;
        public DateTime StartDate => _startDate;

        private DateTime _endDate;
        public DateTime EndDate => _endDate;

        private string _problemDescription;
        public string ProblemDescription => _problemDescription;

        private string _address;
        public string Address => _address;

        private string _city;
        public string City => _city;

        private string _postalCode;
        public string PostalCode => _postalCode;

        private string _province;
        public string Province => _province;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}