using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Commands
{ 
   public class AddVitalSignCommands : IRequest<Result<int>>
    {
        public DateTime VitalSignsTime { get; set; }
        public int VitalSignsFrequency { get; set; }
        public int VitalSignsId { get; set; }
        public string VitalSignSignature { get; set; }
        public string RecordType { get; set; }
        public int PatientId { get; set; }


        public class AddVitalSignCommandsHandler : IRequestHandler<AddVitalSignCommands, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddVitalSignCommandsHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddVitalSignCommands request, CancellationToken cancellationToken)
            {
                try
                {
                    var vitalSignEntry = await _context.VitalSignTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.Id == request.VitalSignsId,
                                                     cancellationToken);
                    if (vitalSignEntry != null)
                        throw new Exception($"Vital Test with Id {request.VitalSignsId} already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var vitalSignRecord = new VitalSignEntity(
                        request.VitalSignsTime,
                        request.VitalSignsFrequency,
                        request.VitalSignSignature,
                        request.RecordType,
                        patient
                        );

                    await _context.VitalSignTests.AddAsync(vitalSignRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(vitalSignRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
