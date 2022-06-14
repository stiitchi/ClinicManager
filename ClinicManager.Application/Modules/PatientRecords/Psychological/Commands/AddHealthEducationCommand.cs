using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Psychological.Commands
{
     public class AddHealthEducationCommand : IRequest<Result<int>>
    {
        public DateTime HealthEducationTime { get; set; }
        public int HealthEducationFrequency { get; set; }
        public int HealthEducationId { get; set; }
        public string HealthEducationSignature { get; set; }
        public int PatientId { get; set; }


        public class AddHealthEducationCommandHandler : IRequestHandler<AddHealthEducationCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddHealthEducationCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddHealthEducationCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var healthEducationEntry = await _context.HealthCareTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.Id == request.HealthEducationId
                                                     ,cancellationToken);
                    if (healthEducationEntry != null)
                        throw new Exception("Health Education Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var healthEducationRecord = new HealthCareEntity(
                        request.HealthEducationTime,
                        request.HealthEducationFrequency,
                        request.HealthEducationSignature,
                        patient
                        );

                    await _context.HealthCareTests.AddAsync(healthEducationRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(healthEducationRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
