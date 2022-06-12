using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.BedAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Bed.Queries
{
    public class GetAllBedsQuery : IRequest<Result<List<BedDTO>>>
    {
    }

    public class GetAllBedsQueryHandler : IRequestHandler<GetAllBedsQuery, Result<List<BedDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBedsQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<BedDTO>>> Handle(GetAllBedsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BedEntity, BedDTO>> expression = e => new BedDTO
                {
                    BedId = e.Id,
                    WardNumber = e.WardNumber,
                    BedNumber = e.BedNumber,
                    WardId = e.WardId,
                };

                var beds = await _context.Beds
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<BedDTO>>.SuccessAsync(beds);

            }
            catch (Exception ex)
            {
                return await Result<List<BedDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
