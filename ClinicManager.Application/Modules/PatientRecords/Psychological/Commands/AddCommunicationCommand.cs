using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Psychological.Commands
{
     public class AddCommunicationCommand : IRequest<Result<int>>
    {
        public DateTime CommunicationTime { get; set; }
        public int CommunicationFrequency { get; set; }
        public string CommunicationSignature { get; set; }
        public int PatientId { get; set; }


        public class AddCommunicationCommandHandler : IRequestHandler<AddCommunicationCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddCommunicationCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddCommunicationCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var communicationEntry = await _context.CommunicationTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (communicationEntry != null)
                        throw new Exception("Communication Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var communicationRecord = new CommunicationEntity(
                        request.CommunicationTime,
                        request.CommunicationFrequency,
                        request.CommunicationSignature,
                        patient
                        );

                    await _context.CommunicationTests.AddAsync(communicationRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(communicationRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
