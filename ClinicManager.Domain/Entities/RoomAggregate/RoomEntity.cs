using ClinicManager.Domain.Entities.BedAggregate;
using ClinicManager.Domain.Entities.WardAggregate;

namespace ClinicManager.Domain.Entities.RoomAggregate
{
    public class RoomEntity : EntityBase
    {
        public RoomEntity()
        { }
        public RoomEntity(string roomNumber,WardEntity ward)
        {
            _roomNumber = roomNumber;
            _wardId = ward.Id;
        }
        public void Set(string roomNumber, WardEntity ward)
        {
            _roomNumber = roomNumber;
            _wardId = ward.Id;
        }

        private string _roomNumber;
        public string RoomNumber => _roomNumber;

        public WardEntity Ward;
        private int _wardId;
        public int WardId => _wardId;

        private readonly List<BedEntity> _beds = new();
        public virtual IReadOnlyCollection<BedEntity> Beds => _beds;
    }
}
