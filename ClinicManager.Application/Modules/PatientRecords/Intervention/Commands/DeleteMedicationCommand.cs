using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Commands
{
    public class DeleteMedicationCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteMedicationCommandHandler : IRequestHandler<DeleteMedicationCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMedicationCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteMedicationCommand request, CancellationToken cancellationToken)
        {

            var medicationEntry = await _context.MedicationTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.MedicationTests.Remove(medicationEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(medicationEntry.Id);

        }
    }
}
