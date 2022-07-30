using ClinicManager.Application.Interfaces.Services;
using ClinicManager.Application.Modules.User.Commands;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Request;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseApiController<AuthenticationController>
    {
        private IAuthenticationService _authService;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IConfiguration _config;


        public AuthenticationController(IAuthenticationService authService, ILogger<AuthenticationController> logger, IConfiguration config)
        {
            _authService = authService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }
        //NO need to email from UI
        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser([FromBody] RegisterDTO user)
        {
            try
            {
                //TODO Fix Return value    
                return Ok(await _mediator.Send(new RegisterUserCommand()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MobileNo = user.MobileNo,
                    Password = user.Password,
                    Role = user.Role
                    //Url = _config.GetValue<string>("ApplicationUrl")
                }));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error registering user." });
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(TokenRequest dtoUser)
        {
            return Ok(await _mediator.Send(new LoginCommand()
            {
                Email = dtoUser.Email,
                Password = dtoUser.Password
            }));
        }
    }
}

