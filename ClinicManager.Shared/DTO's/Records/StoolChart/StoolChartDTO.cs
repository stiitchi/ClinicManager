
namespace ClinicManager.Shared.DTO_s.Records
{
    public class StoolChartDTO
    {
        public int StoolChartId { get; set; }
        public bool NormalBowelMovement { get; set; }
        public bool Blood { get; set; }
        public int PatientId { get; set; }
        public int MuscousAmount { get; set; }
        public string BowelAmount { get; set; }
        public string Consistency { get; set; }
        public string StoolColour { get; set; }
        public DateTime StoolTime { get; set; }
        public DateTime StoolDate { get; set; }
    }
}
