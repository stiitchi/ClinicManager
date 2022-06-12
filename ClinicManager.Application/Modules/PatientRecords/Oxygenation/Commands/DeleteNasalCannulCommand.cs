using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Commands
{
     public class DeleteNasalCannulCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteNasalCannulCommandHandler : IRequestHandler<DeleteNasalCannulCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteNasalCannulCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteNasalCannulCommand request, CancellationToken cancellationToken)
        {
            var nasalCannulEntry = await _context.NasalCannulTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.NasalCannulTests.Remove(nasalCannulEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(nasalCannulEntry.Id);
        }
    }
}
