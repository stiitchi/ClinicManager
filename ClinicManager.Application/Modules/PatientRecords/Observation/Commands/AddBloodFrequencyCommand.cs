using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Commands
{
       public class AddBloodFrequencyCommand : IRequest<Result<int>>
       {
        public DateTime BloodTime { get; set; }
        public int BloodFrequency { get; set; }
        public int BloodId { get; set; }
        public string BloodSignature { get; set; }
        public string RecordType { get; set; }
        public int PatientId { get; set; }


        public class AddBloodFrequencyCommandHandler : IRequestHandler<AddBloodFrequencyCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddBloodFrequencyCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddBloodFrequencyCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var bloodFrequency = await _context.BloodTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.Id == request.BloodId
                                                     ,cancellationToken);
                    if (bloodFrequency != null)
                        throw new Exception($"Blood Record with Id {request.BloodId} already exists");
                    
                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var bloodRecord = new BloodEntity(
                        request.BloodTime,
                        request.BloodFrequency,
                        request.BloodSignature,
                        request.RecordType,
                        patient
                        );

                    await _context.BloodTests.AddAsync(bloodRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(bloodRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
