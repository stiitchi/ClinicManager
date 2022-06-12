using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Safety.Commands
{
     public class DeleteCheckIDBandCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCheckIDBandCommandHandler : IRequestHandler<DeleteCheckIDBandCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCheckIDBandCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteCheckIDBandCommand request, CancellationToken cancellationToken)
        {

            var idBandEntry = await _context.CheckIdBandTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.CheckIdBandTests.Remove(idBandEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(idBandEntry.Id);

        }
    }
}
