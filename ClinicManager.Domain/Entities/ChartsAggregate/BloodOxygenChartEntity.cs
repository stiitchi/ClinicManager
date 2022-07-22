using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.ChartsAggregate
{
    public class BloodOxygenChartEntity : EntityBase
    {
        public BloodOxygenChartEntity()
        { }

        public BloodOxygenChartEntity(double chartEntry, string time, PatientEntity patient)
        {
            _bloodOxygenChartEntry      = chartEntry;
            _time                       = time;
            _patientId                  = patient.Id;
        }

        private double _bloodOxygenChartEntry;
        public double BloodOxygenChartEntry => _bloodOxygenChartEntry;

        private string _time;
        public string Time => _time;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;

        private readonly List<BloodOxygenChartEntryEntity> _bloodOxygenChartEntries = new();
        public virtual IReadOnlyCollection<BloodOxygenChartEntryEntity> BloodOxygenChartEntries => _bloodOxygenChartEntries;
    }
}

