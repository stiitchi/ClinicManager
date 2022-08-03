using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Patient.Commands
{
    public class DeletePatientCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeletePatientCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _context.Patients.Where(a => a.Id == request.Id).FirstOrDefaultAsync();

            var bed = await _context.Beds.Where(a => a.PatientId == request.Id).FirstOrDefaultAsync();

            bed.RemovePatientFromBed(patient);

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(patient.Id);
        }
    }
}
