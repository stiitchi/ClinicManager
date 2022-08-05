using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.BedAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Bed.Queries
{
        public class GetAllBedsByRoomIdQuery : IRequest<Result<List<BedDTO>>>
        {
        public int RoomId { get; set; }
        }

        public class GetAllBedsByRoomIdQueryHandler : IRequestHandler<GetAllBedsByRoomIdQuery, Result<List<BedDTO>>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllBedsByRoomIdQueryHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<List<BedDTO>>> Handle(GetAllBedsByRoomIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    Expression<Func<BedEntity, BedDTO>> expression = e => new BedDTO
                    {
                        BedId        = e.Id,
                        RoomNumber   = e.RoomNumber,
                        BedNumber    = e.BedNumber,
                        RoomId       = e.RoomId
                    };

                    var beds = await _context.Beds
                            .AsNoTracking()
                            .IgnoreQueryFilters()
                            .Where(x => x.RoomId == request.RoomId)
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
