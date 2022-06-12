using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Commands
{
    public class AddBedBathRecordCommand : IRequest<Result<int>>
    {
        public DateTime BedBathTime { get; set; }
        public int BedBathFreq { get; set; }
        public string BedBathSignature { get; set; }
        public int PatientId { get; set; }


        public class AddBedBathRecordCommandHandler : IRequestHandler<AddBedBathRecordCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddBedBathRecordCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddBedBathRecordCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var hygieneEntry = await _context.BedBathTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (hygieneEntry != null)
                        throw new Exception("Hygiene Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var hygieneRecord = new BedBathEntity(
                        request.BedBathTime,
                        request.BedBathFreq,
                        request.BedBathSignature,
                        patient
                        );

                    await _context.BedBathTests.AddAsync(hygieneRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(hygieneRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
