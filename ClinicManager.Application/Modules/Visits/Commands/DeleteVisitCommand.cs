using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Visits.Commands
{
    public class DeleteVisitCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteVisitCommandHandler : IRequestHandler<DeleteVisitCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteVisitCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteVisitCommand request, CancellationToken cancellationToken)
        {
            var visitation = await _context.PatientVisits.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.PatientVisits.Remove(visitation);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(visitation.Id);
        }
    }
}
