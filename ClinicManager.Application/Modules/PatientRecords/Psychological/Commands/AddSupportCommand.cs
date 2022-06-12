using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Psychological.Commands
{
    public class AddSupportCommand : IRequest<Result<int>>
    {
        public DateTime SupportTime { get; set; }
        public int SupportFrequency { get; set; }
        public string SupportSignature { get; set; }
        public int PatientId { get; set; }


        public class AddSupportCommandHandler : IRequestHandler<AddSupportCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddSupportCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddSupportCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var supportEntry = await _context.SupportTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (supportEntry != null)
                        throw new Exception("Support Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var supportRecord = new SupportEntity(
                        request.SupportTime,
                        request.SupportFrequency,
                        request.SupportSignature,
                        patient
                        );

                    await _context.SupportTests.AddAsync(supportRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(supportRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
