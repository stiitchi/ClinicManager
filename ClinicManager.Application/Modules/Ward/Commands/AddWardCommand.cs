using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.BedAggregate;
using ClinicManager.Domain.Entities.WardAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Ward.Commands
{
    public class AddWardCommand : IRequest<Result<int>>
    {
        public int WardId { get; set; }
        public int WardNumber { get; set; }
        public int RoomNumber { get; set; }
        public int TotalBeds { get; set; }
    }

    public class AddWardCommandHandler : IRequestHandler<AddWardCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddWardCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddWardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var wards = await _context.Wards.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.WardId, cancellationToken);
                if (wards != null)
                    throw new Exception("Ward already exists");

                var ward = new WardEntity(
                    request.WardNumber,
                    request.RoomNumber,
                    request.TotalBeds
                    );

                //var bed = new BedEntity(
                //    0,
                //    0,
                //    ward.WardNumber.ToString(),
                //    ward
                //    );

                await _context.Wards.AddAsync(ward, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                //for (int i = 0; i < ward.TotalBeds; i++)
                //{
                //    ward.CreateBeds(bed);
                //}

                //foreach (var item in ward.Beds)
                //{
                //    await _context.Beds.AddAsync(item, cancellationToken);
                //    await _context.SaveChangesAsync(cancellationToken);
                //}

                return await Result<int>.SuccessAsync(ward.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
