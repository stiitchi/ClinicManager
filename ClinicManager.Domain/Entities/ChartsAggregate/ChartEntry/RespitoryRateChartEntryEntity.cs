namespace ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry
{
    public class RespitoryRateChartEntryEntity : EntityBase
    {
        public RespitoryRateChartEntryEntity()
        { }

        public RespitoryRateChartEntryEntity(double chartEntry, RespitoryRateChartEntity respitoryRateChart)
        {
            _respitoryRateChartEntry = chartEntry;
            _respitoryRateChartId    = respitoryRateChart.Id;
        }

        private double _respitoryRateChartEntry;
        public double RespitoryRateChartEntry => _respitoryRateChartEntry;

        public RespitoryRateChartEntity RespitoryRateChart;
        public int RespitoryRateChartId => _respitoryRateChartId;
        private int _respitoryRateChartId;

    }
}
