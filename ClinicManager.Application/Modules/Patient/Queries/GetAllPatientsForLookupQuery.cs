using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Domain.Entities.UserAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static ClinicManager.Shared.Constants.Constants;

namespace ClinicManager.Application.Modules.Patient.Queries
{
   public class GetAllPatientsForLookupQuery : IRequest<Result<List<LookupDTO>>>
    {
    }

    public class GetAllPatientsForLookupQueryHandler : IRequestHandler<GetAllPatientsForLookupQuery, Result<List<LookupDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPatientsForLookupQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<LookupDTO>>> Handle(GetAllPatientsForLookupQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PatientEntity, LookupDTO>> expression = e => new LookupDTO
                {
                    Id    = e.Id,
                    Name  = e.FirstName,
                    Prop1 = e.LastName,
                    Prop2 = e.IsAdmitted.ToString()
                };

                var users = await _context.Patients
                    .AsNoTracking()
                    .Select(expression)
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
