using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Prescription.Commands
{
    public class DeletePrescriptionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePrescriptionCommandHandlers : IRequestHandler<DeletePrescriptionCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeletePrescriptionCommandHandlers(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeletePrescriptionCommand request, CancellationToken cancellationToken)
        {

            var prescription = await _context.Prescriptions.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.Prescriptions.Remove(prescription);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(prescription.Id);

        }
    }
}
