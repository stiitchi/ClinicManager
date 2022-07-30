using ClinicManager.Shared.DTO_s;

namespace ClinicManager.Shared.Request
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string UserImageURL { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public UserDTO User { get; set; }
        public List<UserRolesDTO> UserRoles { get; set; } = new();
    }
}
