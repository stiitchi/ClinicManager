using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Nurses.Commands
{
    public class EditNurseCommand : IRequest<Result<UserDTO>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
    }

    public class EditNurseCommandHandler : IRequestHandler<EditNurseCommand, Result<UserDTO>>
    {
        private readonly IApplicationDbContext _context;

        public EditNurseCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<UserDTO>> Handle(EditNurseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                if (user == null)
                    throw new Exception("User does not exist");

                user.Set(
                    request.FirstName,
                    request.LastName,
                    request.MobileNo
                    );

                await _context.SaveChangesAsync(cancellationToken);
                return await Result<UserDTO>.SuccessAsync(user.FirstName);
            }
            catch (Exception ex)
            {
                return await Result<UserDTO>.FailAsync(ex.Message);
            }
        }
    }
}
