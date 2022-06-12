using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Doctor.Commands
{
  public class EditDoctorCommand : IRequest<Result<UserDTO>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Role { get; set; }
    }

    public class EditDoctorCommandHandler : IRequestHandler<EditDoctorCommand, Result<UserDTO>>
    {
        private readonly IApplicationDbContext _context;

        public EditDoctorCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<UserDTO>> Handle(EditDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                if (user == null)
                    throw new Exception("Doctor does not exist");

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
