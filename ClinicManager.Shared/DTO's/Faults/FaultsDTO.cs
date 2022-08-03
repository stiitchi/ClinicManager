using ClinicManager.Shared.Constants;

namespace ClinicManager.Shared.DTO_s.Faults
{
    public class FaultsDTO
    {
        public int Id { get; set; }

        public FaultTypes FaultTypes { get; set; }

        public string Severity { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime SeenOn { get; set; }

        public int UserId { get; set; }

        public bool IsResolved { get; set; }
    }
}
