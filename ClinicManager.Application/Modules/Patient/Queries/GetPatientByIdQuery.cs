using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static ClinicManager.Shared.Constants.Constants;

namespace ClinicManager.Application.Modules.Patient.Queries
{
  public class GetPatientByIdQuery : IRequest<Result<UserDTO>>
    {
        public int Id { get; set; }
    }

    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Result<UserDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetPatientByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<UserDTO>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var nurse = await _context.Users.AsNoTracking()
                    .IgnoreQueryFilters()
                    .Where(r => r.Role == RoleConstants.PATIENT)
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (nurse == null)
                    throw new Exception("Unable to return Nurse");
                var dto = new UserDTO
                {
                    FirstName = nurse.FirstName,
                    LastName = nurse.LastName,
                    MobileNo = nurse.MobileNo,
                    Email = nurse.Email
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
