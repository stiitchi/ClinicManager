using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.WardAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Ward.Queries
{
    public class GetAllWardsForLookupQuery : IRequest<Result<List<LookupDTO>>>
    {
    }

    public class GetAllWardsForLookupQueryHandler : IRequestHandler<GetAllWardsForLookupQuery, Result<List<LookupDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllWardsForLookupQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<LookupDTO>>> Handle(GetAllWardsForLookupQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<WardEntity, LookupDTO>> expression = e => new LookupDTO
                {
                    Id = e.Id,
                    Name = e.RoomNumber.ToString(),
                    Prop1 = e.TotalBeds.ToString(),
                    Prop2 = e.WardNumber
                };

                var wards = await _context.Wards
                    .AsNoTracking()
                    .Select(expression)
                    .ToListAsync(cancellationToken);
                return await Result<List<LookupDTO>>.SuccessAsync(wards);
            }
            catch (Exception ex)
            {
                return await Result<List<LookupDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
