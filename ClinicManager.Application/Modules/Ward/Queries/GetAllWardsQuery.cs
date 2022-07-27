using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.WardAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Ward.Queries
{
   public class GetAllWardsQuery : IRequest<Result<List<WardDTO>>>
    {
    }

    public class GetAllWardsQueryHandler : IRequestHandler<GetAllWardsQuery, Result<List<WardDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllWardsQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<WardDTO>>> Handle(GetAllWardsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<WardEntity, WardDTO>> expression = e => new WardDTO
                {
                    WardId = e.Id,
                    WardNumber = e.WardNumber,
                    TotalRooms = e.TotalRooms
                };

                var wards = await _context.Wards
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<WardDTO>>.SuccessAsync(wards);

            }
            catch (Exception ex)
            {
                return await Result<List<WardDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
