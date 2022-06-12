using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Commands
{
     public class AddSpecialRecordCommand : IRequest<Result<int>>
    {
        public DateTime SpecialTime { get; set; }
        public int SpecialFrequency { get; set; }
        public string SpecialSignature { get; set; }
        public int PatientId { get; set; }


        public class AddSpecialRecordCommandHandler : IRequestHandler<AddSpecialRecordCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddSpecialRecordCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddSpecialRecordCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var specialEntry = await _context.SpecialTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (specialEntry != null)
                        throw new Exception("NPO Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var specialRecord = new SpecialEntity(
                        request.SpecialTime,
                        request.SpecialFrequency,
                        request.SpecialSignature,
                        patient
                        );

                    await _context.SpecialTests.AddAsync(specialRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(specialRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
