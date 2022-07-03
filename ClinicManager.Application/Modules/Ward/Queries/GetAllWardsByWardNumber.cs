using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Ward.Queries
{
    public class GetAllWardsByWardNumber : IRequest<Result<WardDTO>>
    {
        public int WardNumber { get; set; }
    }

    public class GetAllWardsByWardNumberHandler : IRequestHandler<GetAllWardsByWardNumber, Result<WardDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllWardsByWardNumberHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<WardDTO>> Handle(GetAllWardsByWardNumber request, CancellationToken cancellationToken)
        {
            try
            {
                var ward = await _context.Wards.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.WardNumber == request.WardNumber, cancellationToken);

                if (ward == null)
                    throw new Exception("Unable to return Ward");
                var dto = new WardDTO
                {
                    WardId = ward.Id,
                    WardNumber = ward.WardNumber,
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
