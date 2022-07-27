using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Domain.Entities.RoomAggregate;
using ClinicManager.Domain.Entities.UserAggregate;

namespace ClinicManager.Domain.Entities.BedAggregate
{
    public class BedEntity : EntityBase
    {
        public BedEntity()
        {}
        public BedEntity(int bedNumber, RoomEntity room)
        {
            _bedNumber = bedNumber;
            _roomNumber = room.RoomNumber;
            _roomId = room.Id;
        }
        public BedEntity(int bedId, int bedNumber, RoomEntity room)
        {
            _id = bedId;
            _bedNumber = bedNumber;
            _roomNumber = room.RoomNumber;
            _roomId = room.Id;
        }
        public void Set(int bedNumber, RoomEntity room)
        {
            _bedNumber = bedNumber;
            _roomNumber = room.RoomNumber;
            _roomId = room.Id;
        }

        public void AssignPatientToBed(PatientEntity patient)
        {
            _patientId = patient.Id;
        }

        public void AssignNurseToBed(int nurseId)
        {
            _nurseId = nurseId;
        }

        private int _bedNumber;
        public int BedNumber => _bedNumber;

        private string _roomNumber;
        public string RoomNumber => _roomNumber;

        public PatientEntity Patient;
        private int? _patientId;
        public int? PatientId => _patientId;

        public UserEntity Nurse;

        private int? _nurseId;
        public int? NurseId => _nurseId;

        public RoomEntity Room;

        private int? _roomId;
        public int? RoomId => _roomId;

        private readonly List<PatientBedEntity> _patientBeds = new();
        public virtual IReadOnlyCollection<PatientBedEntity> PatientBeds => _patientBeds;

    }
}
