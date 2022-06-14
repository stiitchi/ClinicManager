using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Commands
{
    public class AddTractionCommand : IRequest<Result<int>>
    {
        public DateTime TractionTime { get; set; }
        public int TractionFreq { get; set; }
        public int TractionId { get; set; }
        public string TractionSignature { get; set; }
        public int PatientId { get; set; }


        public class AddTractionCommandHandler : IRequestHandler<AddTractionCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddTractionCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddTractionCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var tractionEntry = await _context.TractionTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.Id == request.TractionId, cancellationToken);
                    if (tractionEntry != null)
                        throw new Exception("Traction Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var tractionRecord = new TractionEntity(
                        request.TractionTime,
                        request.TractionFreq,
                        request.TractionSignature,
                        patient
                        );

                    await _context.TractionTests.AddAsync(tractionRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(tractionRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
