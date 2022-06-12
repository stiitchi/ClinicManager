

namespace ClinicManager.Shared.DTO_s
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string ImageUrl { get; set; }
        public string Role { get; set; }
    }
}
