using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Commands
{
    public class DeleteWoundCareCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteWoundCareCommandHandler : IRequestHandler<DeleteWoundCareCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteWoundCareCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteWoundCareCommand request, CancellationToken cancellationToken)
        {

            var woundCareEntry = await _context.WoundCareTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.WoundCareTests.Remove(woundCareEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(woundCareEntry.Id);

        }
    }
}
