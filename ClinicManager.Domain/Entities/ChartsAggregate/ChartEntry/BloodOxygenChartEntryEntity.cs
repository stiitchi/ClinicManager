using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry
{
    public class BloodOxygenChartEntryEntity : EntityBase
    {
        public BloodOxygenChartEntryEntity()
        { }

        public BloodOxygenChartEntryEntity(double chartEntry, BloodOxygenChartEntity bloodOxygenChart)
        {
            _bloodOxygenChartEntry = chartEntry;
            _bloodOxygenChartId = bloodOxygenChart.Id;
        }

        private double _bloodOxygenChartEntry;
        public double BloodOxygenChartEntry => _bloodOxygenChartEntry;
     
        public BloodOxygenChartEntity BloodOxygenChart;
        private int _bloodOxygenChartId;
        public int BloodOxygenChartId => _bloodOxygenChartId;
    }
}
