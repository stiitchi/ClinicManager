using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.DayFeesAggregate
{
    public class PatientDayFeesEntity : EntityBase
    {
        public PatientDayFeesEntity()
        {
        }

        public PatientDayFeesEntity(PatientEntity patient, DayFeesEntity dayfee, string dayFeeCode, string dayFeeDescription)
        {
            _patientId = patient.Id;
            _dayFeesId = dayfee.Id;
            _dayFeeCode = dayFeeCode;
            _dayFeeDescription = dayFeeDescription;
        }
        public void Set(PatientEntity patient, DayFeesEntity dayfee, string dayFeeCode, string dayFeeDescription)
        {
            _patientId = patient.Id;
            _dayFeesId = dayfee.Id;
            _dayFeeCode = dayFeeCode;
            _dayFeeDescription = dayFeeDescription;
        }

        private string _dayFeeCode;
        public string DayFeeCode => _dayFeeCode;

        private string _dayFeeDescription;
        public string DayFeeDescription => _dayFeeDescription;

        public DayFeesEntity DayFees { get; set; }
        public int DayFeesId => _dayFeesId;
        private int _dayFeesId;
        public PatientEntity Patient { get; set; }
        public int PatientId => _patientId;
        private int _patientId;
    }
}
