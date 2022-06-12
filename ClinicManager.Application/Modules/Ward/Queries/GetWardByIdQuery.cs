using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Ward.Queries
{
    public class GetWardByIdQuery : IRequest<Result<WardDTO>>
    {
        public int Id { get; set; }
    }

    public class GetWardByIdQueryHandler : IRequestHandler<GetWardByIdQuery, Result<WardDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetWardByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<WardDTO>> Handle(GetWardByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var ward = await _context.Wards.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (ward == null)
                    throw new Exception("Unable to return Ward");
                var dto = new WardDTO
                {
                    WardId = ward.Id,
                    RoomNumber = ward.RoomNumber,
                    TotalBeds = ward.TotalBeds
                };
                return await Result<WardDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<WardDTO>.FailAsync(ex.Message);
            }
        }
    }
}
