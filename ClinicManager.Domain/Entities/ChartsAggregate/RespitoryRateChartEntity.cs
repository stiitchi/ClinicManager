using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.ChartsAggregate
{

    public class RespitoryRateChartEntity : EntityBase
    {
        public RespitoryRateChartEntity()
        { }

        public RespitoryRateChartEntity(double chartEntry, string time, PatientEntity patient)
        {
            _respitoryChartEntry = chartEntry;
            _time = time;
            _patientId = patient.Id;
        }

        private double _respitoryChartEntry;
        public double RespitoryChartEntry => _respitoryChartEntry;

        private string _time;
        public string Time => _time;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
        public virtual IReadOnlyCollection<RespitoryRateChartEntryEntity> RespitoryRateChartEntries => _respitoryRateChartEntries;
        private readonly List<RespitoryRateChartEntryEntity> _respitoryRateChartEntries = new();
    }
}
