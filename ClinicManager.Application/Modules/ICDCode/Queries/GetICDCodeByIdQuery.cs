using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.ICDCode.Queries
{
    public class GetICDCodeByIdQuery : IRequest<Result<ICDCodeDTO>>
    {
        public int Id { get; set; }
    }

    public class GetICDCodeByIdQueryHandler : IRequestHandler<GetICDCodeByIdQuery, Result<ICDCodeDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetICDCodeByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<ICDCodeDTO>> Handle(GetICDCodeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var icdCode = await _context.ICDCodes.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (icdCode == null)
                    throw new Exception("Unable to return ICD Code");
                var dto = new ICDCodeDTO
                {
                    ICDCode = icdCode.IcdCode,
                    Description = icdCode.IcdDescription,
                    DateAdded = icdCode.DateAdded
                };
                return await Result<ICDCodeDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<ICDCodeDTO>.FailAsync(ex.Message);
            }
        }
    }
}
