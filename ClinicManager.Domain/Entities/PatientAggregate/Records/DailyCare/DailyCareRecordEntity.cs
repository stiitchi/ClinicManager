
namespace ClinicManager.Domain.Entities.PatientAggregate.Records.DailyCare
{
    public class DailyCareRecordEntity : EntityBase
    {
        public DailyCareRecordEntity()
        {}

        public DailyCareRecordEntity(DateTime dateAdded, DateTime timeAdded, string careRecord, PatientEntity patient)
        {
            _patientId = patient.Id;
            _dateAdded = dateAdded;
            _timeAdded = timeAdded;
            switch (careRecord)
            {
                case "BedbathShower":
                    _careRecord = CareRecordsEnum.BedbathShower.ToString();
                    break;
                case "LinenChange":
                    _careRecord = CareRecordsEnum.LinenChange.ToString();
                    break;
                case "MouthCare":
                    _careRecord = CareRecordsEnum.MouthCare.ToString();
                    break;
                case "PressurePart":
                    _careRecord = CareRecordsEnum.PressurePart.ToString();
                    break;
                case "PositionChange":
                    _careRecord = CareRecordsEnum.PositionChange.ToString();
                    break;
                case "NappyChange":
                    _careRecord = CareRecordsEnum.NappyChange.ToString();
                    break;
                case "WalkChair":
                    _careRecord = CareRecordsEnum.UpInWalkChair.ToString();
                    break;
                default:
                    break;
            }
        }

        public void Set(DateTime dateAdded, DateTime timeAdded, string careRecord, PatientEntity patient)
        {
            _patientId = patient.Id;
            _dateAdded = dateAdded;
            _timeAdded = timeAdded;
            switch (careRecord)
            {
                case "BedbathShower":
                    _careRecord = CareRecordsEnum.BedbathShower.ToString();
                    break;
                case "LinenChange":
                    _careRecord = CareRecordsEnum.LinenChange.ToString();
                    break;
                case "MouthCare":
                    _careRecord = CareRecordsEnum.MouthCare.ToString();
                    break;
                case "PressurePart":
                    _careRecord = CareRecordsEnum.PressurePart.ToString();
                    break;
                case "PositionChange":
                    _careRecord = CareRecordsEnum.PositionChange.ToString();
                    break;
                case "NappyChange":
                    _careRecord = CareRecordsEnum.NappyChange.ToString();
                    break;
                case "WalkChair":
                    _careRecord = CareRecordsEnum.UpInWalkChair.ToString();
                    break;
                default:
                    break;
            }
        }
        public enum CareRecordsEnum
        {
            BedbathShower = 1,
            LinenChange = 2,
            MouthCare = 3,
            PressurePart = 4,
            PositionChange = 5,
            NappyChange = 6,
            UpInWalkChair = 7,
        }

        private string _careRecord;
        public string CareRecord => _careRecord;

        private DateTime _dateAdded;
        public DateTime DateAdded => _dateAdded;

        private DateTime _timeAdded;
        public DateTime TimeAdded => _timeAdded;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
