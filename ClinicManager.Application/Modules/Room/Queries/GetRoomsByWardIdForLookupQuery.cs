using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.RoomAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Room.Queries
{
    public class GetRoomsByWardIdForLookupQuery : IRequest<Result<List<LookupDTO>>>
    {
        public int WardId { get; set; }
    }

    public class GetRoomsByWardIdForLookupQueryHandler : IRequestHandler<GetRoomsByWardIdForLookupQuery, Result<List<LookupDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetRoomsByWardIdForLookupQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<LookupDTO>>> Handle(GetRoomsByWardIdForLookupQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<RoomEntity, LookupDTO>> expression = e => new LookupDTO
                {
                    Id = e.Id,
                    Name = e.RoomNumber.ToString(),
                    Prop1 = e.WardId.ToString()
                };

                var room = await _context.Rooms
                    .AsNoTracking()
                    .Where(x => x.WardId == request.WardId)
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
