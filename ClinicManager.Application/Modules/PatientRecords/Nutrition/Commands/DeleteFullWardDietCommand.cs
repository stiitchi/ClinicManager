using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Commands
{
    public class DeleteFullWardDietCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteFullWardDietCommandHandler : IRequestHandler<DeleteFullWardDietCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteFullWardDietCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteFullWardDietCommand request, CancellationToken cancellationToken)
        {

            var wardDietEntry = await _context.WardDietTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.WardDietTests.Remove(wardDietEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(wardDietEntry.Id);

        }
    }
}
