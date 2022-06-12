using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Commands
{
    public class DeletePostOperativeCareCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePostOperativeCareCommandHandler : IRequestHandler<DeletePostOperativeCareCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeletePostOperativeCareCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeletePostOperativeCareCommand request, CancellationToken cancellationToken)
        {

            var postOperativeEntry = await _context.PostOperativeCareTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.PostOperativeCareTests.Remove(postOperativeEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(postOperativeEntry.Id);

        }
    }
}
