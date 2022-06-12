using ClinicManager.Application.Models;

namespace ClinicManager.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        string GenerateJWTToken(UserModel user);

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
    }
}
