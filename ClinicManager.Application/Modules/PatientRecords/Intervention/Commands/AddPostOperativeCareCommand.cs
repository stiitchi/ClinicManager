using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Commands
{
     public class AddPostOperativeCareCommand : IRequest<Result<int>>
    {
        public DateTime PostOperativeCareTime { get; set; }
        public int PostOperativeCareFreq { get; set; }
        public string PostOperativeCareSignature { get; set; }
        public int PatientId { get; set; }


        public class AddPostOperativeCareCommandHandler : IRequestHandler<AddPostOperativeCareCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddPostOperativeCareCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddPostOperativeCareCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var interventionEntry = await _context.PostOperativeCareTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (interventionEntry != null)
                        throw new Exception("Intervention Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var interventionRecord = new PostOperativeCareEntity(
                        request.PostOperativeCareTime,
                        request.PostOperativeCareFreq,
                        request.PostOperativeCareSignature,
                        patient
                        );

                    await _context.PostOperativeCareTests.AddAsync(interventionRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(interventionRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
