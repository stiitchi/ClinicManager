using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Commands
{
     public class DeleteMobileImmobileCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteMobileImmobileCommandHandler : IRequestHandler<DeleteMobileImmobileCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMobileImmobileCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteMobileImmobileCommand request, CancellationToken cancellationToken)
        {

            var mobilityEntry = await _context.MobileImmobileTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.MobileImmobileTests.Remove(mobilityEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(mobilityEntry.Id);

        }
    }
}
