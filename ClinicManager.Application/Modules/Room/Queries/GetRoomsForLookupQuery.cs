using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.RoomAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Room.Queries
{
    public class GetRoomsForLookupQuery : IRequest<Result<List<LookupDTO>>>
    {
        public int RoomId { get; set; }
    }

    public class GetRoomsForLookupQueryHandler : IRequestHandler<GetRoomsForLookupQuery, Result<List<LookupDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetRoomsForLookupQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<LookupDTO>>> Handle(GetRoomsForLookupQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<RoomEntity, LookupDTO>> expression = e => new LookupDTO
                {
                    Id      = e.Id,
                    Name    = e.RoomNumber.ToString(),
                    Prop1   = e.WardId.ToString()
                };

                var room = await _context.Rooms
                    .AsNoTracking()
                    .Select(expression)
                    .ToListAsync(cancellationToken);
                return await Result<List<LookupDTO>>.SuccessAsync(room);
            }
            catch (Exception ex)
            {
                return await Result<List<LookupDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
