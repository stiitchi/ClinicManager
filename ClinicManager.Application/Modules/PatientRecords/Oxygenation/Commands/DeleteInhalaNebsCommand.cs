using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Commands
{
    public class DeleteInhalaNebsCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteInhalaNebsCommandHandler : IRequestHandler<DeleteInhalaNebsCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteInhalaNebsCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteInhalaNebsCommand request, CancellationToken cancellationToken)
        {

            var inhalaNebEntry = await _context.InhalaNebsTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.InhalaNebsTests.Remove(inhalaNebEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(inhalaNebEntry.Id);

        }
    }
}
