
namespace ClinicManager.Shared.DTO_s
{
    public class BedDTO
    {
        public int BedId { get; set; }
        public int BedNumber { get; set; }
        public string? RoomNumber { get; set; }
        public string? PatientName { get; set; }
        public int NurseId { get; set; }
        public int? RoomId { get; set; }
        public int? PatientId { get; set; }
    }
}
