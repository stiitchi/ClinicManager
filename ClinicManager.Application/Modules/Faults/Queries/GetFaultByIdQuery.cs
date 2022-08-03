using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Faults;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Faults.Queries
{
    public class GetFaultByIdQuery : IRequest<Result<FaultsDTO>>
    {
        public int Id { get; set; }
    }

    public class GetFaultByIdQueryHandler : IRequestHandler<GetFaultByIdQuery, Result<FaultsDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetFaultByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<FaultsDTO>> Handle(GetFaultByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var fault = await _context.Faults.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (fault == null)
                    throw new Exception("Unable to return Fault");

                var dto = new FaultsDTO
                {
                    Id              = fault.Id,
                    Description     = fault.Description,
                    CreatedOn       = fault.CreatedOn,
                    SeenOn          = fault.SeenOn,
                    IsResolved      = fault.IsResolved,
                    Severity        = fault.Serverity,
                    UserId          = fault.UserId
                };
                return await Result<FaultsDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<FaultsDTO>.FailAsync(ex.Message);
            }
        }
    }
}
