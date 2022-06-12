
namespace ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance
{
    public class IVTestEntity : EntityBase
    {
        public IVTestEntity()
        {}
        public IVTestEntity(int intakeMl, DateTime timeStart, DateTime timeComplete, int volumeStart, int volumeComplete,
                                       bool ivcheck, string ivDesc, int runningTotalIV, string ivCheckType, PatientEntity patient)
        {
            _intravenousIntakeMl = intakeMl;
            _intravenousIntakeTime = timeStart;
            _intravenousIntakeTimeCompleted = timeComplete;
            _intravenousIntakeStartVolume = volumeStart;
            _intravenousIntakeCompleteVolume = volumeComplete;
            _ivCheck = ivcheck;
            _ivDescription = ivDesc;
            _intravenousRunningTotal = runningTotalIV;
            _patientId = patient.Id;
            switch (ivCheckType)
            {
                case "Needle":
                    _ivCheckType = IVChecksEnum.Needle.ToString();
                    break;
                default:
                    break;
            }
        }

        private int _intravenousIntakeMl;
        public int IntravenousIntakeMl => _intravenousIntakeMl;

        private DateTime _intravenousIntakeTime;
        public DateTime IntravenousIntakeTime => _intravenousIntakeTime;

        private DateTime _intravenousIntakeTimeCompleted;
        public DateTime IntravenousIntakeTimeCompleted => _intravenousIntakeTimeCompleted;

        private int _intravenousIntakeStartVolume;
        public int IntravenousIntakeStartVolume => _intravenousIntakeStartVolume;

        private int _intravenousIntakeCompleteVolume;
        public int IntravenousIntakeCompleteVolume => _intravenousIntakeCompleteVolume;

        private bool _ivCheck;
        public bool IvCheck => _ivCheck;

        private string _ivDescription;
        public string IvDescription => _ivDescription;

        private int _intravenousRunningTotal;
        public int IntravenousRunningTotal => _intravenousRunningTotal;

        private string _ivCheckType;
        public string IvCheckType => _ivCheckType;
        public enum IVChecksEnum
        {
            Needle = 1,
            Catherer = 2,
            RectalTube = 3
        }

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
