using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Commands
{
    public class AddPolyMaskCommand : IRequest<Result<int>>
    {
        public DateTime PolyMaskTime { get; set; }
        public int PolyMaskFrequency { get; set; }
        public string PolyMaskSignature { get; set; }
        public int PatientId { get; set; }


        public class AddPolyMaskCommandHandler : IRequestHandler<AddPolyMaskCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddPolyMaskCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddPolyMaskCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var polyMaskTimeEntry = await _context.PolyMaskTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (polyMaskTimeEntry != null)
                        throw new Exception("oly Mask Time Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var polyMaskTimeRecord = new PolyMaskEntity(
                        request.PolyMaskTime,
                        request.PolyMaskFrequency,
                        request.PolyMaskSignature,
                        patient
                        );

                    await _context.PolyMaskTests.AddAsync(polyMaskTimeRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(polyMaskTimeRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
