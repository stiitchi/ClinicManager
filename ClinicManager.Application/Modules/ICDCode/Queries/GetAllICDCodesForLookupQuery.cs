using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ICDCodeAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.ICDCode.Queries
{
    public class GetAllICDCodesForLookupQuery : IRequest<Result<List<LookupDTO>>>
    {
    }

    public class GetAllICDCodesForLookupQueryHandler : IRequestHandler<GetAllICDCodesForLookupQuery, Result<List<LookupDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllICDCodesForLookupQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<LookupDTO>>> Handle(GetAllICDCodesForLookupQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<ICDCodeEntity, LookupDTO>> expression = e => new LookupDTO
                {
                    Id = e.Id,
                    Name = e.IcdCode,
                    Prop1 = e.IcdDescription,
                    Prop2 = e.DateAdded.ToString()
                };

                var icdCode = await _context.ICDCodes
                    .AsNoTracking()
                    .Select(expression)
                    .ToListAsync(cancellationToken);
                return await Result<List<LookupDTO>>.SuccessAsync(icdCode);
            }
            catch (Exception ex)
            {
                return await Result<List<LookupDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
