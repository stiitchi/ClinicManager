
namespace ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance
{
    public class OralIntakeTestEntity : EntityBase
    {
        public OralIntakeTestEntity()
        {}
        public OralIntakeTestEntity(int intakeMl, DateTime oralIntakeTime, int volume,
                                         int runningTotalOral, string oralCheckType, PatientEntity patient)
        {
            _oralIntakeMl = intakeMl;
            _oralIntakeTime = oralIntakeTime;
            _oralIntakeVolume = volume;
            _runningTotalOral = runningTotalOral;
            _patientId = patient.Id;
            switch (oralCheckType)
            {
                case "Stetoscope":
                    _oralCheckType = OralChecks.Stetoscope.ToString();
                    break;
                default:
                    break;
            }
        }

        private int _oralIntakeMl;
        public int OralIntakeMl => _oralIntakeMl;

        private DateTime _oralIntakeTime;
        public DateTime OralIntakeTime => _oralIntakeTime;

        private int _oralIntakeVolume;
        public int OralIntakeVolume => _oralIntakeVolume;

        private int _runningTotalOral;
        public int RunningTotalOral => _runningTotalOral;

        private string _oralCheckType;
        public string OralCheckType => _oralCheckType;
        public enum OralChecks
        {
            Stetoscope = 1
        }

        private int _outputMl;
        public int OutputMl => _outputMl;

        private bool _isUrine;
        public bool IsUrine => _isUrine;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
