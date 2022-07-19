
using ClinicManager.Domain.Entities.BedAggregate;
using ClinicManager.Domain.Entities.DoctorsAggregate;

namespace ClinicManager.Domain.Entities.WardAggregate
{
    public class WardEntity : EntityBase
    {
        public WardEntity()
        {
        }

        public WardEntity(string wardNumber, int roomNumber, int totalBeds)
        {
            _wardNumber = wardNumber;
            _roomNumber = roomNumber;
            _totalBeds = totalBeds;
        }
        public void Set(string wardNumber, int roomNumber, int totalBeds)
        {
            _wardNumber = wardNumber;
            _roomNumber = roomNumber;
            _totalBeds = totalBeds;
        }

        public void AddOccupied(int total)
        {
            _occupiedBeds = total + 1;
        }
        public void AddUnoccupied(int total)
        {
            _unOccupiedBeds = total - 1;
        }
        public void AddBedToWard(int total)
        {     
            _totalBeds = total + 1;
        }
        public void DeleteBedToWard(int total)
        {
            _totalBeds = total - 1;
        }
        public void CreateBeds(BedEntity beds)
        {
            _beds.Add(beds);
        }

        private string _wardNumber;
        public string WardNumber => _wardNumber;

        private int _roomNumber;
        public int RoomNumber => _roomNumber;

        private int _totalBeds;         
        public int TotalBeds => _totalBeds;

        private int _occupiedBeds;
        public int OccupiedBeds => _occupiedBeds;

        private int _unOccupiedBeds;
        public int UnOccupiedBeds => _unOccupiedBeds;

        private readonly List<BedEntity> _beds = new();
        public virtual IReadOnlyCollection<BedEntity> Beds => _beds;

        private readonly List<DoctorEntity> _doctors = new();
        public virtual IReadOnlyCollection<DoctorEntity> Doctors => _doctors;

    }
}
        