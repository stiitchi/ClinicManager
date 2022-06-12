namespace ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance
{
    public class OralOutputEntity : EntityBase
    {
        public OralOutputEntity()
        {}

        public OralOutputEntity(int outputMl, DateTime timeStart, 
                                 bool isUrine, int runningTotalOralOutput,
                                PatientEntity patient)
        {
            _outputMl = outputMl;
            _oralOutputTime = timeStart;
            _isUrine = isUrine;
            _runningOutputTotal = runningTotalOralOutput;
            _patientId = patient.Id;
        }

        private int _outputMl;
        public int OutputMl => _outputMl;

        private int _runningOutputTotal;
        public int RunningOutputTotal => _runningOutputTotal;

        private DateTime _oralOutputTime;
        public DateTime OralOutputTime => _oralOutputTime;

        private bool _isUrine;
        public bool IsUrine => _isUrine;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
