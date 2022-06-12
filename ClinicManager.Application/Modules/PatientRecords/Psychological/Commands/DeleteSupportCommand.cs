using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Psychological.Commands
{
     public class DeleteSupportCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSupportCommandHandler : IRequestHandler<DeleteSupportCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSupportCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteSupportCommand request, CancellationToken cancellationToken)
        {

            var supportEntry = await _context.SupportTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.SupportTests.Remove(supportEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(supportEntry.Id);

        }
    }
}
