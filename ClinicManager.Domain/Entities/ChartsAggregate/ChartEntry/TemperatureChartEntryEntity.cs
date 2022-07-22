namespace ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry
{
    public class TemperatureChartEntryEntity : EntityBase
    {
        public TemperatureChartEntryEntity()
        { }

        public TemperatureChartEntryEntity(double chartEntry, TemperatureChartEntity temperatureChart)
        {
            _temperatureChartEntry = chartEntry;
            _temperatureChartId    = temperatureChart.Id;
        }

        public double TemperatureChartEntry => _temperatureChartEntry;
        private double _temperatureChartEntry;

        public TemperatureChartEntity TemperatureChart;
        public int TemperatureChartId => _temperatureChartId;
        private int _temperatureChartId;

    }
}
