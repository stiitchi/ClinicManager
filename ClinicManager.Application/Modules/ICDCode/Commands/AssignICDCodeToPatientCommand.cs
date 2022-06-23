using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ICDCodeAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.ICDCode.Commands
{
    public class AssignICDCodeToPatientCommand : IRequest<Result<int>>
    {
        public int PatientICDCodeId { get; set; }
        public string ICDCodeId { get; set; }
        public int PatientId { get; set; }
    }

    public class AssignICDCodeToPatientCommandHandler : IRequestHandler<AssignICDCodeToPatientCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AssignICDCodeToPatientCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AssignICDCodeToPatientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var patientICDCodes = await _context.PatientICDCodes.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.IcdCode == request.ICDCodeId, cancellationToken);
                if (patientICDCodes != null)
                    throw new Exception("Patient is already assigned to this ICD Code");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var ICDCodes = await _context.ICDCodes.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.IcdCode == request.ICDCodeId, cancellationToken);
                if (ICDCodes == null)
                    throw new Exception("Patient is already assigned to this ICD Code");

                var patientICDCode = new PatientICDCodeEntity(
                    patient,
                    ICDCodes,
                    ICDCodes.IcdCode,
                    ICDCodes.IcdDescription
                    );

                await _context.PatientICDCodes.AddAsync(patientICDCode, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(patientICDCode.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
