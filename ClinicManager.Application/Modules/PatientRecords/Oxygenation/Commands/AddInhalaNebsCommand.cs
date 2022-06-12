using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Commands
{
    public class AddInhalaNebsCommand : IRequest<Result<int>>
    {
        public DateTime InhalaNebsTime { get; set; }
        public int InhalaNebsFrequency { get; set; }
        public string InhalaNebsSignature { get; set; }
        public int PatientId { get; set; }


        public class AddInhalaNebsCommandHandler : IRequestHandler<AddInhalaNebsCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddInhalaNebsCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddInhalaNebsCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var inhalaNebsEntry = await _context.InhalaNebsTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (inhalaNebsEntry != null)
                        throw new Exception("Inhala Nebs Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var inhalaNebsRecord = new InhalaNebsEntity(
                        request.InhalaNebsTime,
                        request.InhalaNebsFrequency,
                        request.InhalaNebsSignature,
                        patient
                        );

                    await _context.InhalaNebsTests.AddAsync(inhalaNebsRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(inhalaNebsRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
