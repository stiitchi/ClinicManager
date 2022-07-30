using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Application.Interfaces.Services;
using ClinicManager.Application.Models;
using ClinicManager.Domain.Entities.UserAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.User.Commands
{
    public class AddUserCommand : IRequest<Result<int>>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
    }

    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IAuthenticationService _authenticationService;

        public AddUserCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _context.Users.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.UserId, cancellationToken);
                if (users != null)
                    throw new Exception("User already exists");

                UserModel newUser = new();

                newUser.Id = request.UserId;
                newUser.FullName = $"{request.Name}{request.LastName}";
                newUser.Email = request.Email;

                var user = new UserEntity(
                request.Name,
                request.LastName,
                request.Email,
                request.MobileNo
                );

                await _context.Users.AddAsync(user, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);


                return await Result<int>.SuccessAsync(user.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
