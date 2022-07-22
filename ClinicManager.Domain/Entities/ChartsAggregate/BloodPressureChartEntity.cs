using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.ChartsAggregate
{
    public class BloodPressureChartEntity : EntityBase
    {
        public BloodPressureChartEntity()
        { }

        public BloodPressureChartEntity(double chartEntry, string time, PatientEntity patient)
        {
            _bloodPressureChartEntry = chartEntry;
            _time = time;
            _patientId = patient.Id;
        }

        private double _bloodPressureChartEntry;
        public double BloodPressureChartEntry => _bloodPressureChartEntry;

        private string _time;
        public string Time => _time;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;

        private readonly List<BloodPressureChartEntryEntity> _bloodPressureChartEntries = new();
        public virtual IReadOnlyCollection<BloodPressureChartEntryEntity> BloodPressureChartEntries => _bloodPressureChartEntries;
    }
}
