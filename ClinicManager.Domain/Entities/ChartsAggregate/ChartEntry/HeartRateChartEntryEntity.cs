namespace ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry
{
    public class HeartRateChartEntryEntity : EntityBase
    {
        public HeartRateChartEntryEntity()
        { }

        public HeartRateChartEntryEntity(double chartEntry, HeartRateChartEntity heartRateChart)
        {
            _heartRateChartEntry = chartEntry;
            _heartRateChartId = heartRateChart.Id;
        }

        private double _heartRateChartEntry;
        public double HeartRateChartEntry => _heartRateChartEntry;

        public HeartRateChartEntity HeartRateChart;
        public int HeartRateChartId => _heartRateChartId;
        private int _heartRateChartId;

    }
}
