using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static ClinicManager.Shared.Constants.Constants;

namespace ClinicManager.Application.Modules.Doctor.Queries
{
   public class GetDoctorByIdQuery : IRequest<Result<UserDTO>>
    {
        public int Id { get; set; }
    }

    public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Result<UserDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetDoctorByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<UserDTO>> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var nurse = await _context.Users.AsNoTracking()
                    .IgnoreQueryFilters()
                    .Where(r => r.Role == RoleConstants.DOCTOR)
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (nurse == null)
                    throw new Exception("Unable to return Doctor");
                var dto = new UserDTO
                {
                    FirstName   = nurse.FirstName,
                    LastName    = nurse.LastName,
                    MobileNo    = nurse.MobileNo,
                    Email       = nurse.Email
                };
                return await Result<UserDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<UserDTO>.FailAsync(ex.Message);
            }
        }
    }
}
