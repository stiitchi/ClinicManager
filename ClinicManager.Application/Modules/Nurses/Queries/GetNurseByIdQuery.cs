using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static ClinicManager.Shared.Constants.Constants;

namespace ClinicManager.Application.Modules.Nurses.Queries
{
    public class GetNurseByIdQuery : IRequest<Result<UserDTO>>
    {
        public int Id { get; set; }
    }

    public class GetNurseByIdQueryHandler : IRequestHandler<GetNurseByIdQuery, Result<UserDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetNurseByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<UserDTO>> Handle(GetNurseByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var nurse = await _context.Users.AsNoTracking()
                    .IgnoreQueryFilters()
                    .Where(r => r.Role == RoleConstants.NURSE)
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
