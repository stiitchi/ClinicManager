
namespace ClinicManager.Domain.Entities.UserAggregate
{
    public class UserRolesEntity : EntityBase
    {
        public UserRolesEntity()
        {
        }

        public UserRolesEntity(UserEntity user, RoleEntity role)
        {
            _userId = user.Id;
            _roleId = role.Id;
        }
        public void Set(UserEntity user, RoleEntity role)
        {
            _userId = user.Id;
            _roleId = role.Id;
        }
        public RoleEntity Role { get; set; }
        public int RoleId => _roleId;
        private int _roleId;
        public UserEntity User { get; set; }
        public int UserId => _userId;
        private int _userId;
    }
}
