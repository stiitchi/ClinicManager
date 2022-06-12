using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.UserAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static ClinicManager.Shared.Constants.Constants;

namespace ClinicManager.Application.Modules.Doctor.Queries
{
    public class GetAllDoctorsForLookupQuery : IRequest<Result<List<LookupDTO>>>
    {
    }

    public class GetAllDoctorsForLookupQueryHandler : IRequestHandler<GetAllDoctorsForLookupQuery, Result<List<LookupDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllDoctorsForLookupQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<LookupDTO>>> Handle(GetAllDoctorsForLookupQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<UserEntity, LookupDTO>> expression = e => new LookupDTO
                {
                    Id = e.Id,
                    Name = e.FirstName,
                    Prop1 = e.LastName,
                    Prop2 = e.MobileNo,
                    Prop3 = e.Role
                };

                var users = await _context.Users
                    .AsNoTracking()
                    .Select(expression)
                    .Where(r => r.Prop3 == RoleConstants.DOCTOR)
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
