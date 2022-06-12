using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Commands
{
     public class AddMaskTimeCommand : IRequest<Result<int>>
    {
        public DateTime MaskTime { get; set; }
        public int MaskFrequency { get; set; }
        public string MaskSignature { get; set; }
        public int PatientId { get; set; }


        public class AddMaskTimeCommandHandler : IRequestHandler<AddMaskTimeCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddMaskTimeCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddMaskTimeCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var maskTimeEntry = await _context.MaskTimeTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (maskTimeEntry != null)
                        throw new Exception("Mask Time Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var maskTimeRecord = new MaskTimeEntity(
                        request.MaskTime,
                        request.MaskFrequency,
                        request.MaskSignature,
                        patient
                        );

                    await _context.MaskTimeTests.AddAsync(maskTimeRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(maskTimeRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
