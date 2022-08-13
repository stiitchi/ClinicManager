using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientAllergies.Commands
{
    public class DeletePatientAllergyCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePatientAllergyCommandHandler : IRequestHandler<DeletePatientAllergyCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeletePatientAllergyCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeletePatientAllergyCommand request, CancellationToken cancellationToken)
        {
            var allergy = await _context.PatientAllergies.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.PatientAllergies.Remove(allergy);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(allergy.Id);
        }
    }
}
