
using ClinicManager.Domain.Entities.BedAggregate;

namespace ClinicManager.Domain.Entities.WardAggregate
{
    public class WardEntity : EntityBase
    {
        public WardEntity()
        {
        }

        public WardEntity(int wardNumber, int roomNumber, int totalBeds)
        {
            _wardNumber = wardNumber;
            _roomNumber = roomNumber;
            _totalBeds = totalBeds;
        }
        public void Set(int wardNumber, int roomNumber, int totalBeds)
        {
            _wardNumber = wardNumber;
            _roomNumber = roomNumber;
            _totalBeds = totalBeds;
        }

        public void CreateBeds(BedEntity beds)
        {
            _beds.Add(beds);
        }

        private int _wardNumber;
        public int WardNumber => _wardNumber;

        private int _roomNumber;
        public int RoomNumber => _roomNumber;

        private int _totalBeds;         
        public int TotalBeds => _totalBeds;

        private readonly List<BedEntity> _beds = new();
        public virtual IReadOnlyCollection<BedEntity> Beds => _beds;
    }
}
        