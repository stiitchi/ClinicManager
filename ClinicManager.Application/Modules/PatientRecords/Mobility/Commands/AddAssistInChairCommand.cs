using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Commands
{
    public class AddAssistInChairCommand : IRequest<Result<int>>
    {
        public DateTime AssistIntoChairTime { get; set; }
        public int AssistIntoChairFrequency { get; set; }
        public string AssistIntoChairSignature { get; set; }
        public int PatientId { get; set; }


        public class AddAssistInChairCommandHandler : IRequestHandler<AddAssistInChairCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddAssistInChairCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddAssistInChairCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var chairAssistEntry = await _context.WalkChairTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (chairAssistEntry != null)
                        throw new Exception("Mobility Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var chairAssistRecord = new WalkChairEntity(
                        request.AssistIntoChairTime,
                        request.AssistIntoChairFrequency,
                        request.AssistIntoChairSignature,
                        patient
                        );

                    await _context.WalkChairTests.AddAsync(chairAssistRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(chairAssistRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
