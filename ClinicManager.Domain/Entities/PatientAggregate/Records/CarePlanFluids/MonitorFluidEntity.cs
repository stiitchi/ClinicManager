namespace ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanFluids
{
    public class MonitorFluidEntity : EntityBase
    {
        public MonitorFluidEntity()
        { }
        public MonitorFluidEntity(TimeSpan time, int frequency, string signature, PatientEntity patient)
        {
            _monitorFluidTime = time;
            _monitorFluidFrequency = frequency;
            _monitorFluidSignature = signature;
            _patientId = patient.Id;
        }

        private TimeSpan _monitorFluidTime;
        public TimeSpan MonitorFluidTime => _monitorFluidTime;

        private int _monitorFluidFrequency;
        public int MonitorFluidFrequency => _monitorFluidFrequency;

        private string _monitorFluidSignature;
        public string MonitorFluidSignature => _monitorFluidSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
