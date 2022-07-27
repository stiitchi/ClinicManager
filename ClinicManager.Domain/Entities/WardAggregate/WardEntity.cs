using ClinicManager.Domain.Entities.DoctorsAggregate;
using ClinicManager.Domain.Entities.RoomAggregate;

namespace ClinicManager.Domain.Entities.WardAggregate
{
    public class WardEntity : EntityBase
    {
        public WardEntity()
        {
        }

        public WardEntity(string wardNumber, int totalRooms)
        {
            _wardNumber = wardNumber;
            _totalRooms = totalRooms;
        }
        public void Set(string wardNumber, int totalRooms)
        {
            _wardNumber = wardNumber;
            _totalRooms = totalRooms;
        }

        private string _wardNumber;
        public string WardNumber => _wardNumber;

        private int _totalRooms;         
        public int TotalRooms => _totalRooms;


        private readonly List<RoomEntity> _rooms = new();
        public virtual IReadOnlyCollection<RoomEntity> Rooms => _rooms;

        private readonly List<DoctorEntity> _doctors = new();
        public virtual IReadOnlyCollection<DoctorEntity> Doctors => _doctors;
    }
}
        