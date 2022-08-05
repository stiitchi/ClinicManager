using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.UserAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static ClinicManager.Shared.Constants.Constants;

namespace ClinicManager.Application.Modules.Admissions.Queries
{
    public class GetAdmissionsForLookupQuery : IRequest<Result<List<LookupDTO>>>
    {
    }

    public class GetAdmissionsForLookupQueryHandler : IRequestHandler<GetAdmissionsForLookupQuery, Result<List<LookupDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAdmissionsForLookupQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<LookupDTO>>> Handle(GetAdmissionsForLookupQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<UserEntity, LookupDTO>> expression = e => new LookupDTO
                {
                    Id    = e.Id,
                    Name  = e.FirstName,
                    Prop1 = e.LastName,
                    Prop2 = e.MobileNo,
                    Prop3 = e.Role
                };

                var users = await _context.Users
                    .AsNoTracking()
                    .Select(expression)
                    .Where(r => r.Prop3 == RoleConstants.ADMITTED)
                    .ToListAsync(cancellationToken);
                return await Result<List<LookupDTO>>.SuccessAsync(users);
            }
            catch (Exception ex)
            {
                return await Result<List<LookupDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
