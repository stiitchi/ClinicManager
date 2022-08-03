using ClinicManager.Domain.Entities.UserAggregate;

namespace ClinicManager.Domain.Entities.NotificationAggregate
{
    public class NotificationEntity : EntityBase
    {
        public NotificationEntity()
        {}

        public NotificationEntity(string type, string description, DateTime createdOn, UserEntity user)
        {
            _type           = type;
            _description    = description;
            _createdOn      = createdOn;
            _userId         = user.Id;
        }

        public void SetNoticationAsSeen(DateTime seenOn)
        {
            _seenOn = seenOn;
        }

        public string Type => _type;
        private string _type;
        
        public string Description => _description;
        private string _description;

        public DateTime CreatedOn => _createdOn;
        private DateTime _createdOn;

        public DateTime SeenOn => _seenOn;
        private DateTime _seenOn;

        public UserEntity User;
        private int _userId;
        public int UserId => _userId;
    }
}
