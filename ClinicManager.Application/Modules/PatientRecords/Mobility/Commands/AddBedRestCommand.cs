using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Commands
{
    public class AddBedRestCommand : IRequest<Result<int>>
    {
        public DateTime BedRestTime { get; set; }
        public int BedRestFrequency { get; set; }
        public string BedRestSignature { get; set; }
        public int PatientId { get; set; }


        public class AddBedRestCommandHandler : IRequestHandler<AddBedRestCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddBedRestCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddBedRestCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var bedRestEntry = await _context.BedRestTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (bedRestEntry != null)
                        throw new Exception("Bed Rest Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var bedRestRecord = new BedRestEntity(
                        request.BedRestTime,
                        request.BedRestFrequency,
                        request.BedRestSignature,
                        patient
                        );

                    await _context.BedRestTests.AddAsync(bedRestRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(bedRestRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
