namespace ClinicManager.Shared.DTO_s
{
    public class RoomDTO
    {
        public int RoomId { get; set; }
        public int WardId { get; set; }
        public string WardNumber { get; set; }
        public string RoomNumber { get; set; }
        public int TotalBeds { get; set; }
        public int? OccupiedBeds { get; set; }
        public int? UnoccupiedBeds{ get; set; }
    }
}
