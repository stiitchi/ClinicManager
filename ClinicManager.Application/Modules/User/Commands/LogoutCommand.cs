using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Application.Interfaces.Services;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.User.Commands
{
    public class LogoutCommand : IRequest<Result<int>>
    {
        public int UserId { get; set; }
    }

    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IAuthenticationService _authenticationService;

        public LogoutCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.UserId, cancellationToken);
                if (user != null)
                    throw new Exception("User already exists");

                user.SetAsLoggedOut();

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
