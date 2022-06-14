using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Commands
{
    public class AddNeuroVascularCommand : IRequest<Result<int>>
    {
        public DateTime NeuroVascularTime { get; set; }
        public int NeuroVascularFrequency { get; set; }
        public int NeuroVascularId { get; set; }
        public string NeuroVascularSignature { get; set; }
        public string RecordType { get; set; }
        public int PatientId { get; set; }


        public class AddNeuroVascularCommandHandler : IRequestHandler<AddNeuroVascularCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddNeuroVascularCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddNeuroVascularCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var neuroVascularEntry = await _context.NeurovascularTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.Id == request.NeuroVascularId
                                                     ,cancellationToken);

                     if (neuroVascularEntry != null)
                        throw new Exception($"Neuro Vascular  with Id {request.NeuroVascularId} already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var neuroVascularRecord = new NeurovascularEntity(
                        request.NeuroVascularTime,
                        request.NeuroVascularFrequency,
                        request.NeuroVascularSignature,
                        request.RecordType,
                        patient
                        );

                    await _context.NeurovascularTests.AddAsync(neuroVascularRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(neuroVascularRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
