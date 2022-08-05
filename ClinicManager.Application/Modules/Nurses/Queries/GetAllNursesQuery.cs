using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.UserAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static ClinicManager.Shared.Constants.Constants;

namespace ClinicManager.Application.Modules.Nurses.Queries
{
   public class GetAllNursesQuery : IRequest<Result<List<UserDTO>>>
    {
    }

    public class GetAllNursesQueryHandler : IRequestHandler<GetAllNursesQuery, Result<List<UserDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllNursesQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<UserDTO>>> Handle(GetAllNursesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<UserEntity, UserDTO>> expression = e => new UserDTO
                {
                    Id          = e.Id,
                    FirstName   = e.FirstName,
                    LastName    = e.LastName,
                    Email       = e.Email,
                    MobileNo    = e.MobileNo
                };

                var nurses = await _context.Users
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.Role == RoleConstants.NURSE)
                        .ToListAsync(cancellationToken);
                return await Result<List<UserDTO>>.SuccessAsync(nurses);

            }
            catch (Exception ex)
            {
                return await Result<List<UserDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
