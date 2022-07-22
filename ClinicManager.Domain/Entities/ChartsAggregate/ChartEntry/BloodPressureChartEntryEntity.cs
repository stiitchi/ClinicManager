namespace ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry
{
    public class BloodPressureChartEntryEntity : EntityBase
    {
        public BloodPressureChartEntryEntity()
        { }

        public BloodPressureChartEntryEntity(double chartEntry, BloodPressureChartEntity bloodPressureChart)
        {
            _bloodPressureChartEntry = chartEntry;
            _bloodPressureChartId = bloodPressureChart.Id;
        }

        private double _bloodPressureChartEntry;
        public double BloodPressureChartEntry => _bloodPressureChartEntry;

        public BloodPressureChartEntity BloodPressureChart;
        public int BloodPressureChartId => _bloodPressureChartId;
        private int _bloodPressureChartId;

    }
}
