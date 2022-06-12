
namespace ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance
{
    public class Previous24HourIntakeEntity : EntityBase
    {
        public Previous24HourIntakeEntity()
        {}

        public Previous24HourIntakeEntity(int intake24Hour, int output24Hour, int totalIntake, DateTime dateToday, PatientEntity patient)
        {
            _previous24HourIntake = intake24Hour;
            _previous24HourOutput = output24Hour;
            _total24HourIntake = totalIntake;
            _dateToday = dateToday;
            _patientId = patient.Id;
        }

        private DateTime _dateToday;
        public DateTime DateToday => _dateToday;

        private int _previous24HourIntake;
        public int Previous24HourIntake => _previous24HourIntake;

        private int _previous24HourOutput;
        public int Previous24HourOutput => _previous24HourOutput;

        private int _total24HourIntake;
        public int Total24HourIntake => _total24HourIntake;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
