using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Commands
{
    public class DeleteTractionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTractionCommandHandler : IRequestHandler<DeleteTractionCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTractionCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteTractionCommand request, CancellationToken cancellationToken)
        {

            var tractionEntry = await _context.TractionTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.TractionTests.Remove(tractionEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(tractionEntry.Id);

        }
    }
}
