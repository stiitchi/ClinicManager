using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Commands
{
      public class AddBloodGlucoseCommand : IRequest<Result<int>>
        {
        public DateTime BloodGlucoseTime { get; set; }
        public int BloodGlucoseFrequency { get; set; }
        public int BloodGlucoseId { get; set; }
        public string BloodGlucoseSignature { get; set; }
        public string RecordType { get; set; }
        public int PatientId { get; set; }


        public class AddBloodGlucoseCommandHandler : IRequestHandler<AddBloodGlucoseCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddBloodGlucoseCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddBloodGlucoseCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var bloodGlucoseEntry = await _context.BloodGlucoseTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.Id == request.BloodGlucoseId, 
                                                     cancellationToken);
                    if (bloodGlucoseEntry != null)
                        throw new Exception($"Blood Glucose Record with Id {request.BloodGlucoseId} already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var bloodGlucoseRecord = new BloodGlucoseEntity(
                        request.BloodGlucoseTime,
                        request.BloodGlucoseFrequency,
                        request.BloodGlucoseSignature,
                        request.RecordType,
                        patient
                        );

                    await _context.BloodGlucoseTests.AddAsync(bloodGlucoseRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(bloodGlucoseRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
