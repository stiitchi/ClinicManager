using ClinicManager.Domain.Entities.UserAggregate;

namespace ClinicManager.Domain.Entities.FaultAggregate
{
    public class FaultEntity : EntityBase
    {
        public FaultEntity()
        { }

        public FaultEntity(string type, string description, DateTime createdOn, string severity, UserEntity user)
        {
            _type        = type;
            _description = description;
            _createdOn   = createdOn;
            _serverity   = severity;
            _userId      = user.Id;
            _isResolved  = false;
        }

        public void SetToResolved()
        {
            _isResolved = true;
        }

        public string Type => _type;
        private string _type;

        public string Serverity => _serverity;
        private string _serverity;

        public bool IsResolved => _isResolved;
        private bool _isResolved;

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
