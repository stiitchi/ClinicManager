using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ICDCodeAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.ICDCode.Queries
{
    public class GetAllICDCodesQuery : IRequest<Result<List<ICDCodeDTO>>>
    {
    }

    public class GetAllICDCodesQueryHandler : IRequestHandler<GetAllICDCodesQuery, Result<List<ICDCodeDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllICDCodesQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<ICDCodeDTO>>> Handle(GetAllICDCodesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<ICDCodeEntity, ICDCodeDTO>> expression = e => new ICDCodeDTO
                {
                    ICDCodeId   = e.Id,
                    ICDCode     = e.IcdCode,
                    DateAdded   = e.DateAdded,
                    Description = e.IcdDescription
                };

                var icdCode = await _context.ICDCodes
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<ICDCodeDTO>>.SuccessAsync(icdCode);

            }
            catch (Exception ex)
            {
                return await Result<List<ICDCodeDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}

