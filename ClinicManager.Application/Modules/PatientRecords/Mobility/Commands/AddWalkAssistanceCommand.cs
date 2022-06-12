using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Commands
{
    public class AddWalkAssistanceCommand : IRequest<Result<int>>
    {
        public DateTime WalkWithAssistanceTime { get; set; }
        public int WalkWithAssistanceFrequency { get; set; }
        public string WalkWithAssistanceSignature { get; set; }
        public int PatientId { get; set; }


        public class AddWalkAssistanceCommandHandler : IRequestHandler<AddWalkAssistanceCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddWalkAssistanceCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddWalkAssistanceCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var walkAssistanceEntry = await _context.WalkAssistanceTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (walkAssistanceEntry != null)
                        throw new Exception("Mobility Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var mobilityEntry = new WalkAssistanceEntity(
                        request.WalkWithAssistanceTime,
                        request.WalkWithAssistanceFrequency,
                        request.WalkWithAssistanceSignature,
                        patient
                        );

                    await _context.WalkAssistanceTests.AddAsync(mobilityEntry, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(mobilityEntry.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
