using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Commands
{
     public class AddUrineTestCommand : IRequest<Result<int>>
    {
        public DateTime UrineTestTime { get; set; }
        public int UrineTestFrequency { get; set; }
        public string UrineTestSignature { get; set; }
        public string RecordType { get; set; }
        public int UrineTestId { get; set; }
        public int PatientId { get; set; }


        public class AddUrineTestCommandHandler : IRequestHandler<AddUrineTestCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddUrineTestCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddUrineTestCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var urineTestEntry = await _context.UrineTestTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.Id == request.UrineTestId
                                                     ,cancellationToken);
                    if (urineTestEntry != null)
                        throw new Exception($"Urine Test with Id {request.UrineTestId} already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var urineTestRecord = new UrineTestEntity(
                        request.UrineTestTime,
                        request.UrineTestFrequency,
                        request.UrineTestSignature,
                        request.RecordType,
                        patient
                        );

                    await _context.UrineTestTests.AddAsync(urineTestRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(urineTestRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
