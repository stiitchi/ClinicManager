using ClinicManager.Domain.Exceptions;
using ClinicManager.Domain.Seedwork;

namespace ClinicManager.Domain.Entities.UserAggregate
{
    public class RoleEntity : Enumeration
    {
        public static RoleEntity SYSTEM_ADMINISTRATOR = new RoleEntity(1, "SYSTEM ADMINISTRATOR");
        public static RoleEntity ADMITTED = new RoleEntity(2, "ADMITTED");
        public static RoleEntity DOCTOR = new RoleEntity(3, "DOCTOR");
        public static RoleEntity NURSE = new RoleEntity(4, "NURSE");
        public static RoleEntity SUPER_USER = new RoleEntity(5, "SUPER USER");
        public static RoleEntity PATIENT = new RoleEntity(6, "PATIENT");

        public RoleEntity()
        {
        }

        public RoleEntity(int id, string name) : base(id, name)
        {

        }

        public static List<RoleEntity> List()
        {
            return new()
            {
                SYSTEM_ADMINISTRATOR,
                SUPER_USER,
                DOCTOR,
                NURSE,
                ADMITTED
            };
        }
        public static List<RoleEntity> DoctorList()
        {
            return new()
            {
                DOCTOR
            };
        }
        public static List<RoleEntity> NurseList()
        {
            return new()
            {
                NURSE
            };
        }
        public static List<RoleEntity> AdminList()
        {
            return new()
            {
                SYSTEM_ADMINISTRATOR
            };
        }
        public static List<RoleEntity> UsersList()
        {
            return new()
            {
                SUPER_USER
            };
        }

        public static RoleEntity FromName(string name)
        {
            var state = List()
                        .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
            if (state == null)
            {
                throw new GeneralDomainException($"Possible values for Roles: {String.Join(",", List().Select(s => s.Name))}");
            }
            return state;
        }
        public static RoleEntity From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
            if (state == null)
            {
                throw new GeneralDomainException($"Possible values for Roles: {String.Join(",", List().Select(s => s.Name))}");
            }
            return state;
        }
    }
}
