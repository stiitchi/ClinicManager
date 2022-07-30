using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Application.Interfaces.Services;
using ClinicManager.Domain.Entities.UserAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace ClinicManager.Application.Modules.User.Commands
{
    public class RegisterUserCommand : IRequest<IResult<int>>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IResult<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;

        public RegisterUserCommandHandler(IApplicationDbContext context, IMediator mediator, IAuthenticationService authService, IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _authenticationService = authService ?? throw new ArgumentNullException(nameof(authService));
            _configuration = configuration;
        }

        public async Task<IResult<int>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            { 

                 byte[] hash = Encoding.ASCII.GetBytes(request.Password);
                 byte[] salt = Encoding.ASCII.GetBytes(request.Password);

                _authenticationService.CreatePasswordHash(request.Password, out hash, out salt);


                var user = new UserEntity(request.FirstName, request.LastName, request.Email, request.MobileNo);

                user.SetPassword(hash, salt);

                var userRoles = new UserRolesEntity();


                var role = await _context.Roles.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Name == request.Role, cancellationToken);
                if (role == null)
                    throw new Exception("Role doesn't exist.");

                userRoles.Role = role;
                user.AddUserRole(userRoles);
                


                await _context.Users.AddAsync(user, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                RegisterEmailDTO emailDto = new RegisterEmailDTO()
                {
                    Email = request.Email,
                };

                //var result = await _mediator.Send(new RegisterClientEmailCommand(emailDto));

                return await Result<int>.SuccessAsync(user.Id);
            }
            catch (Exception e)
            {
                return await Result<int>.FailAsync(e.Message);
            }
        }
    }
}

