using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.UserAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static ClinicManager.Shared.Constants.Constants;

namespace ClinicManager.Application.Modules.Nurses.Commands
{
    public class AddNurseCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
    }

    public class AddNurseCommandHandler : IRequestHandler<AddNurseCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddNurseCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddNurseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _context.Users.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                if (users != null)
                    throw new Exception("Nurse already exists");

                var user = new UserEntity(
                   request.FirstName,
                   request.LastName,
                   request.MobileNo
                    );

                user.SetRole(RoleConstants.NURSE);

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
