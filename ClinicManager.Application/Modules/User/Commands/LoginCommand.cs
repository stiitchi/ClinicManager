using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Application.Exceptions;
using ClinicManager.Application.Interfaces.Services;
using ClinicManager.Application.Models;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Request;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.User.Commands
{
    public class LoginCommand : IRequest<IResult<TokenResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, IResult<TokenResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IAuthenticationService _authenticationService;

        public LoginCommandHandler(IApplicationDbContext context, IAuthenticationService authenticationService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public async Task<IResult<TokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users
                    .Include(u => u.UserRoles)
                        .ThenInclude(r => r.Role)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Email.ToLower() == request.Email.ToLower(), cancellationToken);

                if (user == null)
                    throw new ApiException("Invalid email or password");
                if (user.PasswordHash == null && user.PasswordSalt == null)
                    throw new ApiException("Email not activated.");
                var validPassword = _authenticationService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);
                if (!validPassword)
                    throw new ApiException("Invalid email or password");
                var response = new TokenResponse();
                var userModel = new UserModel
                {
                    Email = user.Email,
                    FullName = $"{user.FirstName} {user.LastName}",
                    Id = user.Id
                };

                response.User = new UserDTO
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MobileNo = user.MobileNo
                };
                response.Token = _authenticationService.GenerateJWTToken(userModel);

                user.SetAsLoggedIn();

                foreach (var userRole in user.UserRoles)
                {
                    response.UserRoles.Add(new UserRolesDTO
                    {
                        UserID = userRole.UserId,
                        Role = userRole.Role.Name,
                        RoleID = userRole.RoleId
                    });
                }

                return Result<TokenResponse>.Success(response);
            }
            catch (Exception e)
            {
                return Result<TokenResponse>.Fail(e.Message);
            }
        }
    }
}
