using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Commands
{
    public class AddNeuroLogicalCommand : IRequest<Result<int>>
    {
        public DateTime NeuroLogicalTime { get; set; }
        public int NeuroLogicalFrequency { get; set; }
        public string NeuroLogicalSignature { get; set; }
        public string RecordType { get; set; }
        public int PatientId { get; set; }


        public class AddNeuroLogicalCommandHandler : IRequestHandler<AddNeuroLogicalCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddNeuroLogicalCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddNeuroLogicalCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var neuroLogicalEntry = await _context.NeurologicalTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (neuroLogicalEntry != null)
                        throw new Exception("Neuro Logical already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var neuroLogicalRecord = new NeurologicalEntity(
                        request.NeuroLogicalTime,
                        request.NeuroLogicalFrequency,
                        request.NeuroLogicalSignature,
                        request.RecordType,
                        patient
                        );

                    await _context.NeurologicalTests.AddAsync(neuroLogicalRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(neuroLogicalRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
