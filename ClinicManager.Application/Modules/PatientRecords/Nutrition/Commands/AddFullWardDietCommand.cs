using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Commands
{
    public class AddFullWardDietCommand : IRequest<Result<int>>
    {
        public DateTime FullWardDietTime { get; set; }
        public int FullWardDietFrequency { get; set; }
        public int FullWardDietId { get; set; }
        public string FullWardDietSignature { get; set; }
        public int PatientId { get; set; }


        public class AddFullWardDietCommandHandler : IRequestHandler<AddFullWardDietCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddFullWardDietCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddFullWardDietCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var dietEntry = await _context.WardDietTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.Id == request.FullWardDietId
                                                     ,cancellationToken);
                    if (dietEntry != null)
                        throw new Exception("Diet Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var dietRecord = new WardDietEntity(
                        request.FullWardDietTime,
                        request.FullWardDietFrequency,
                        request.FullWardDietSignature,
                        patient
                        );

                    await _context.WardDietTests.AddAsync(dietRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(dietRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
