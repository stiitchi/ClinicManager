namespace ClinicManager.Shared.DTO_s
{
    public class MovePatientDTO
    {
        public int PatientBedId { get; set; }
        public int PatientId { get; set; }
        public int WardId { get; set; }
        public int BedId { get; set; }
        public int RoomId { get; set; }
    }
}
