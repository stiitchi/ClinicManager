using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Commands
{
    public class AddSelfCareRecordCommand : IRequest<Result<int>>
    {
        public DateTime SelfCareTime { get; set; }
        public int SelfCareFreq { get; set; }
        public int SelfCareId { get; set; }
        public string SelfCareSignature { get; set; }
        public int PatientId { get; set; }


        public class AddSelfCareRecordCommandHandler : IRequestHandler<AddSelfCareRecordCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddSelfCareRecordCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddSelfCareRecordCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var selfCareEntry = await _context.SelfCareTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.Id == request.SelfCareId, cancellationToken);
                    if (selfCareEntry != null)
                        throw new Exception("Self Care Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var selfCareRecord = new SelfCareEntity(
                        request.SelfCareTime,
                        request.SelfCareFreq,
                        request.SelfCareSignature,
                        patient
                        );

                    await _context.SelfCareTests.AddAsync(selfCareRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(selfCareRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
