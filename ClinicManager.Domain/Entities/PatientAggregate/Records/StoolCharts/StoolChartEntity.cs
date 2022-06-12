
namespace ClinicManager.Domain.Entities.PatientAggregate.Records.StoolCharts
{
    public class StoolChartEntity : EntityBase
    {
        public StoolChartEntity()
        {}

        public StoolChartEntity(PatientEntity patient, bool normalBowelMovement, DateTime time, DateTime date,
                                bool blood, int muscousAmount, string bowelMovement,
                                string consitency)
        {
            _patientId = patient.Id;
            _normalBowelHabit = normalBowelMovement;
            _stoolChartTime = time;
            _stoolChartDate = date;
            _blood = blood;
            _mucousAmount = muscousAmount;

            switch (bowelMovement)
            {
                case "Small":
                   _bowelAmount = BowelAmountEnum.Small.ToString();
                    break;
                case "Medium":
                    _bowelAmount = BowelAmountEnum.Medium.ToString();
                    break;
                case "Large":
                    _bowelAmount = BowelAmountEnum.Large.ToString();
                    break;
                default:
                    break;
            }

            switch (consitency)
            {
                case "Type1":
                    _consistency = ConsistencyEnum.Type1.ToString();
                    break;
                case "Type2":
                    _consistency = ConsistencyEnum.Type2.ToString();
                    break;
                case "Type3":
                    _consistency = ConsistencyEnum.Type3.ToString();
                    break;
                case "Type4":
                    _consistency = ConsistencyEnum.Type4.ToString();
                    break;
                case "Type5":
                    _consistency = ConsistencyEnum.Type5.ToString();
                    break;
                case "Type6":
                    _consistency = ConsistencyEnum.Type6.ToString();
                    break;
                case "Type7":
                    _consistency = ConsistencyEnum.Type7.ToString();
                    break;
                default:
                    break;
            }
        }

        public void Set(PatientEntity patient, bool normalBowelMovement, DateTime time, DateTime date,
                               bool blood, int muscousAmount, string bowelMovement,
                               string consitency)
        {
            _patientId = patient.Id;
            _normalBowelHabit = normalBowelMovement;
            _stoolChartTime = time;
            _stoolChartDate = date;
            _blood = blood;
            _mucousAmount = muscousAmount;

            switch (bowelMovement)
            {
                case "Small":
                    _bowelAmount = BowelAmountEnum.Small.ToString();
                    break;
                case "Medium":
                    _bowelAmount = BowelAmountEnum.Medium.ToString();
                    break;
                case "Large":
                    _bowelAmount = BowelAmountEnum.Large.ToString();
                    break;
                default:
                    break;
            }

            switch (consitency)
            {
                case "Type1":
                    _consistency = ConsistencyEnum.Type1.ToString();
                    break;
                case "Type2":
                    _consistency = ConsistencyEnum.Type2.ToString();
                    break;
                case "Type3":
                    _consistency = ConsistencyEnum.Type3.ToString();
                    break;
                case "Type4":
                    _consistency = ConsistencyEnum.Type4.ToString();
                    break;
                case "Type5":
                    _consistency = ConsistencyEnum.Type5.ToString();
                    break;
                case "Type6":
                    _consistency = ConsistencyEnum.Type6.ToString();
                    break;
                case "Type7":
                    _consistency = ConsistencyEnum.Type7.ToString();
                    break;
                default:
                    break;
            }
        }


        private bool _normalBowelHabit;
        public bool NormalBowelHabit => _normalBowelHabit;

        private DateTime _stoolChartDate;
        public DateTime StoolChartDate => _stoolChartDate;

        private DateTime _stoolChartTime;
        public DateTime StoolChartTime => _stoolChartTime;

        private string _stoolColour;
        public string StoolColour => _stoolColour;

        private bool _blood;
        public bool Blood => _blood;

        private int _mucousAmount;
        public int MucousAmount => _mucousAmount;

        private enum BowelAmountEnum
        {
            Small,
            Medium,
            Large
        }

        private string _bowelAmount;
        public string BowelAmount => _bowelAmount;
        private enum ConsistencyEnum
        {
            Type1,
            Type2,
            Type3,
            Type4,
            Type5,
            Type6,
            Type7
        }

        private string _consistency;
        public string Consistency => _consistency;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
