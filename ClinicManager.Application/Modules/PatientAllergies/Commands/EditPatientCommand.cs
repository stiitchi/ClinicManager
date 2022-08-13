using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientAllergies.Commands
{
    public class EditPatientCommand : IRequest<Result<int>>
    {
        public int AllergyId { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
    }

    public class EditPatientCommandHandler : IRequestHandler<EditPatientCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public EditPatientCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(EditPatientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var allergy = await _context.PatientAllergies.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.AllergyId, cancellationToken);
                if (allergy == null)
                    throw new Exception("This allergy does not exist");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient does not exist");

                allergy.Set(
                request.Description,
                patient);

                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(allergy.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
