using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.ChartsAggregate
{
   
    public class HeartRateChartEntity : EntityBase
    {
        public HeartRateChartEntity()
        { }

        public HeartRateChartEntity(double chartEntry, string time, PatientEntity patient)
        {
            _heartRateChartEntry = chartEntry;
            _time = time;
            _patientId = patient.Id;
        }

        private double _heartRateChartEntry;
        public double HeartRateChartEntry => _heartRateChartEntry;

        private string _time;
        public string Time => _time;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
