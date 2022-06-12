using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Psychological.Commands
{
     public class DeleteMaskCommunicationCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteMaskCommunicationCommandHandler : IRequestHandler<DeleteMaskCommunicationCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMaskCommunicationCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteMaskCommunicationCommand request, CancellationToken cancellationToken)
        {

            var maskEntry = await _context.MaskTimeTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.MaskTimeTests.Remove(maskEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(maskEntry.Id);

        }
    }
}
