using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Commands
{
       public class DeleteMaskTimeCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteMaskTimeCommandHandler : IRequestHandler<DeleteMaskTimeCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMaskTimeCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteMaskTimeCommand request, CancellationToken cancellationToken)
        {

            var maskTimeEntry = await _context.MaskTimeTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.MaskTimeTests.Remove(maskTimeEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(maskTimeEntry.Id);

        }
    }
}
