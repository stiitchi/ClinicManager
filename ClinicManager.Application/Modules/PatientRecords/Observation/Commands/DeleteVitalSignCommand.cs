using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Commands
{ 
    public class DeleteVitalSignCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteVitalSignCommandHandler : IRequestHandler<DeleteVitalSignCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteVitalSignCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteVitalSignCommand request, CancellationToken cancellationToken)
        {

            var vitalSignEntry = await _context.VitalSignTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.VitalSignTests.Remove(vitalSignEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(vitalSignEntry.Id);

        }
    }
}
