using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.DayFeesAggregate
{
    public class PatientDayFeesEntity : EntityBase
    {
        public PatientDayFeesEntity()
        {
        }

        public PatientDayFeesEntity(PatientEntity patient, DayFeesEntity dayfee)
        {
            _patientId = patient.Id;
            _dayFeesId = dayfee.Id;
        }
        public void Set(PatientEntity patient, DayFeesEntity dayfee)
        {
            _patientId = patient.Id;
            _dayFeesId = dayfee.Id;
        }

        public DayFeesEntity DayFees { get; set; }
        public int DayFeesId => _dayFeesId;
        private int _dayFeesId;
        public PatientEntity Patient { get; set; }
        public int PatientId => _patientId;
        private int _patientId;
    }
}
