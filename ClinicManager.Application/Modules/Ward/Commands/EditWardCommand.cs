using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Ward.Commands
{
    public class EditWardCommand : IRequest<Result<int>>
    {
        public int WardId { get; set; }
        public string WardNumber { get; set; }
        public int RoomNumber { get; set; }
        public int TotalBeds { get; set; }
    }

    public class EditWardCommandHandler : IRequestHandler<EditWardCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public EditWardCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(EditWardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ward = await _context.Wards.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.WardId, cancellationToken);
                if (ward == null)
                    throw new Exception("Ward does not exist");

                ward.Set(
                    request.WardNumber, 
                    request.RoomNumber,
                    request.TotalBeds
                    );
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(ward.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
