using System.ComponentModel.DataAnnotations;

namespace ClinicManager.Shared.Request
{
    public class TokenRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
