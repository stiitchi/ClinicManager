using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Commands
{
     public class AddBedBathAssistCommand : IRequest<Result<int>>
    {
        public DateTime BedBathAssistTime { get; set; }
        public int BedBathAssistFreq { get; set; }
        public string BedBathAssistSignature { get; set; }
        public int PatientId { get; set; }


        public class AddBedBathAssistCommandHandler : IRequestHandler<AddBedBathAssistCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddBedBathAssistCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddBedBathAssistCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var bedBathEntry = await _context.BedBathAssistTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (bedBathEntry != null)
                        throw new Exception("Bed Bath Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var hygieneRecord = new BedBathAssistEntity(
                        request.BedBathAssistTime,
                        request.BedBathAssistFreq,
                        request.BedBathAssistSignature,
                        patient
                        );

                    await _context.BedBathAssistTests.AddAsync(hygieneRecord, cancellationToken);
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
