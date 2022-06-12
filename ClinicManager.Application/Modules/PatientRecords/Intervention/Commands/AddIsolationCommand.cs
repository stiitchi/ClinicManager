using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Commands
{ 
   public class AddIsolationCommand : IRequest<Result<int>>
    {
        public DateTime IsolationTime { get; set; }
        public int IsolationFreq { get; set; }
        public string IsolationSignature { get; set; }
        public int PatientId { get; set; }


        public class AddIsolationCommandHandler : IRequestHandler<AddIsolationCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddIsolationCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddIsolationCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var isolationEntry = await _context.IsolationTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (isolationEntry != null)
                        throw new Exception("Isolation Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var isolationRecord = new IsolationEntity(
                        request.IsolationTime,
                        request.IsolationFreq,
                        request.IsolationSignature,
                        patient
                        );

                    await _context.IsolationTests.AddAsync(isolationRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(isolationRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
