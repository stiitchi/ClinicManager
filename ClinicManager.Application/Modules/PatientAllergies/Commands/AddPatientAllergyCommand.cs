using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Allergies;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientAllergies.Commands
{
    public class AddPatientAllergyCommand : IRequest<Result<int>>
    {
        public int AllergyId { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
    }

    public class AddPatientAllergyCommandHandler : IRequestHandler<AddPatientAllergyCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddPatientAllergyCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddPatientAllergyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var allergies = await _context.PatientAllergies.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.AllergyId, cancellationToken);
                if (allergies != null)
                    throw new Exception("Allergy already exists");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient != null)
                    throw new Exception("Patient doesn't exists");


                var allergy = new PatientAllergiesEntity(
                    request.Description,
                    patient
                    );

                await _context.PatientAllergies.AddAsync(allergy, cancellationToken);
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
