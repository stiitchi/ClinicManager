using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Faults.Commands
{
    public class DeleteFaultCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteFaultCommandHandler : IRequestHandler<DeleteFaultCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteFaultCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteFaultCommand request, CancellationToken cancellationToken)
        {
            var fault = await _context.Faults.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.Faults.Remove(fault);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(fault.Id);
        }
    }
}
