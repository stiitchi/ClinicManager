using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.ICDCode.Commands
{
    public class DeleteICDCodeCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteICDCodeCommandHandler : IRequestHandler<DeleteICDCodeCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteICDCodeCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteICDCodeCommand request, CancellationToken cancellationToken)
        {
            var iCDCode = await _context.ICDCodes.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.ICDCodes.Remove(iCDCode);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(iCDCode.Id);
        }
    }
}