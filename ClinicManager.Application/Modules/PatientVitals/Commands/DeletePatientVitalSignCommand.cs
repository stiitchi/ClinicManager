using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientVitals.Commands
{
    public class DeletePatientVitalSignCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePatientVitalSignCommandHandler : IRequestHandler<DeletePatientVitalSignCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeletePatientVitalSignCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeletePatientVitalSignCommand request, CancellationToken cancellationToken)
        {

            var vitals = await _context.PatientVitals.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.PatientVitals.Remove(vitals);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(vitals.Id);

        }
    }
}
