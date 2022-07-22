using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.ChartsAggregate
{
    public class TemperatureChartEntity : EntityBase
    {
        public TemperatureChartEntity()
        { }

        public TemperatureChartEntity(double chartEntry, string time, PatientEntity patient)
        {
            _tempRateEntry = chartEntry;
            _time = time;
            _patientId = patient.Id;
        }

        private double _tempRateEntry;
        public double TempRateEntry => _tempRateEntry;

        private string _time;
        public string Time => _time;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
        public virtual IReadOnlyCollection<TemperatureChartEntryEntity> TemperatureChartEntries => _temperatureChartEntries;
        private readonly List<TemperatureChartEntryEntity> _temperatureChartEntries = new();
    }
}
