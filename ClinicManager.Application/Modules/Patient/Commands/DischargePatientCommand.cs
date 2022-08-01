using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Patient.Commands
{
    public class DischargePatientCommand : IRequest<Result<int>>
    {
        public int PatientId { get; set; }
    }

    public class DischargePatientCommandHandler : IRequestHandler<DischargePatientCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DischargePatientCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DischargePatientCommand request, CancellationToken cancellationToken)
        {

            var patient = await _context.Patients.IgnoreQueryFilters()
                                         .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
            patient.DischargePatient();
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(patient.Id);

        }
    }
}
