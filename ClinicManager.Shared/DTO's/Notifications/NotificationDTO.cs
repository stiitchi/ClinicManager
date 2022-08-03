using ClinicManager.Shared.Constants;

namespace ClinicManager.Shared.DTO_s.Notifications
{
    public class NotificationDTO
    {
        public  int Id { get; set; }

        public  NotificationType NotificationType { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime SeenOn { get; set; }

        public int UserId { get; set; }
    }
}
