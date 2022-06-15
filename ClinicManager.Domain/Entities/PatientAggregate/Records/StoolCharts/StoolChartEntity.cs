
using System.ComponentModel;

namespace ClinicManager.Domain.Entities.PatientAggregate.Records.StoolCharts
{
    public class StoolChartEntity : EntityBase
    {
        public StoolChartEntity()
        {}

        public StoolChartEntity(PatientEntity patient, bool normalBowelMovement, DateTime time, DateTime date,
                                bool blood, string colour, int muscousAmount, string bowelMovement,
                                string consitency)
        {
            _patientId = patient.Id;
            _normalBowelHabit = normalBowelMovement;
            _stoolChartTime = time;
            _stoolChartDate = date;
            _blood = blood;
            _stoolColour = colour;
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
                case "Type 1 - Severe Constipation":
                    _consistency = ConsistencyEnum.Type1.ToString();
                    break;
                case "Type 2 - Mild Constipation":
                    _consistency = ConsistencyEnum.Type2.ToString();
                    break;
                case "Type 3 - Normal":
                    _consistency = ConsistencyEnum.Type3.ToString();
                    break;
                case "Type 4 - Normal":
                    _consistency = ConsistencyEnum.Type4.ToString();
                    break;
                case "Type 5 - Lacking Fibre":
                    _consistency = ConsistencyEnum.Type5.ToString();
                    break;
                case "Type 6 - Mild Diarrhea":
                    _consistency = ConsistencyEnum.Type6.ToString();
                    break;
                case "Type 7 - Severe Diarrhea":
                    _consistency = ConsistencyEnum.Type7.ToString();
                    break;
                default:
                    break;
            }
        }

        public void Set(PatientEntity patient, bool normalBowelMovement, DateTime time, DateTime date,
                               bool blood, string stoolColour, int muscousAmount, string bowelMovement,
                               string consitency)
        {
            _patientId = patient.Id;
            _normalBowelHabit = normalBowelMovement;
            _stoolChartTime = time;
            _stoolChartDate = date;
            _blood = blood;
            _stoolColour = stoolColour;
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
                case "Type 1 - Severe Constipation":
                    _consistency = ConsistencyEnum.Type1.ToString();
                    break;
                case "Type 2 - Mild Constipation":
                    _consistency = ConsistencyEnum.Type2.ToString();
                    break;
                case "Type 3 - Normal":
                    _consistency = ConsistencyEnum.Type3.ToString();
                    break;
                case "Type 4 - Normal":
                    _consistency = ConsistencyEnum.Type4.ToString();
                    break;
                case "Type 5 - Lacking Fibre":
                    _consistency = ConsistencyEnum.Type5.ToString();
                    break;
                case "Type 6 - Mild Diarrhea":
                    _consistency = ConsistencyEnum.Type6.ToString();
                    break;
                case "Type 7 - Severe Diarrhea":
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
            [Description("Severe Constipation")]
            Type1,
            [Description("Mild Constipation")]
            Type2,
            [Description("Normal")]
            Type3,
            [Description("Normal")]
            Type4,
            [Description("Lacking Fibre")]
            Type5,
            [Description("Mild Diarrhea")]
            Type6,
            [Description("Severe Diarrhea")]
            Type7
        }

        private string _consistency;
        public string Consistency => _consistency;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
