using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Commands
{
    public class DeleteBedRestCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteBedRestCommandHandler : IRequestHandler<DeleteBedRestCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBedRestCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteBedRestCommand request, CancellationToken cancellationToken)
        {

            var bedRestEntry = await _context.BedRestTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.BedRestTests.Remove(bedRestEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(bedRestEntry.Id);

        }
    }   
}
