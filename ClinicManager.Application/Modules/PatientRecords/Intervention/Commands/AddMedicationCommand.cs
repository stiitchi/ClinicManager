using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Commands
{
     public class AddMedicationCommand: IRequest<Result<int>>
    {
        public DateTime MedicationTime { get; set; }
        public int MedicationFreq { get; set; }
        public string MedicationSignature { get; set; }
        public int PatientId { get; set; }


        public class AddMedicationCommandHandler : IRequestHandler<AddMedicationCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddMedicationCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddMedicationCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var medicationEntry = await _context.MedicationTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (medicationEntry != null)
                        throw new Exception("Intervention Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var medicationRecord = new MedicationEntity(
                        request.MedicationTime,
                        request.MedicationFreq,
                        request.MedicationSignature,
                        patient
                        );

                    await _context.MedicationTests.AddAsync(medicationRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(medicationRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
