using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.BedAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Bed.Queries
{
    public class GetAllBedsForLookupQuery : IRequest<Result<List<LookupDTO>>>
    {
    }

    public class GetAllBedsForLookupQueryHandler : IRequestHandler<GetAllBedsForLookupQuery, Result<List<LookupDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBedsForLookupQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<LookupDTO>>> Handle(GetAllBedsForLookupQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BedEntity, LookupDTO>> expression = e => new LookupDTO
                {
                    Id      = e.Id,
                    Name    = e.BedNumber.ToString(),
                    Prop1   = e.RoomId.ToString(),
                    Prop2   = e.NurseId.ToString(),
                    Prop3   = e.PatientId.ToString(),
                    Prop4   = e.RoomNumber.ToString()
                };

                var bed = await _context.Beds
                    .AsNoTracking()
                    .Select(expression)
                    .ToListAsync(cancellationToken);
                return await Result<List<LookupDTO>>.SuccessAsync(bed);
            }
            catch (Exception ex)
            {
                return await Result<List<LookupDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
