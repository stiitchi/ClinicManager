using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Commands
{
    public class AddNPORecordCommand : IRequest<Result<int>>
    {
        public DateTime KeepNPOTime { get; set; }
        public int KeepNPOFrequency { get; set; }
        public string KeepNPOSignature { get; set; }
        public int PatientId { get; set; }


        public class AddNPORecordCommandHadler : IRequestHandler<AddNPORecordCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddNPORecordCommandHadler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddNPORecordCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var npoEntry = await _context.KeepNPOTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (npoEntry != null)
                        throw new Exception("NPO Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var npoRecord = new KeepNPOEntity(
                        request.KeepNPOTime,
                        request.KeepNPOFrequency,
                        request.KeepNPOSignature,
                        patient
                        );

                    await _context.KeepNPOTests.AddAsync(npoRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(npoRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
