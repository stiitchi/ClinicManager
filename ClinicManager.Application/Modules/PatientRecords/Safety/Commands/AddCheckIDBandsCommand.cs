using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Safety;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Safety.Commands
{
    public class AddCheckIDBandsCommand : IRequest<Result<int>>
    {
        public DateTime CheckIDBandsTime { get; set; }
        public int CheckIDBandsFrequency { get; set; }
        public string CheckIDBandsSignature { get; set; }
        public int PatientId { get; set; }


        public class AddCheckIDBandsCommandHandler : IRequestHandler<AddCheckIDBandsCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddCheckIDBandsCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddCheckIDBandsCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var idBandEntry = await _context.CheckIdBandTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (idBandEntry != null)
                        throw new Exception("ID Band already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var idBandRecord = new CheckIdBandEntity(
                        request.CheckIDBandsTime,
                        request.CheckIDBandsFrequency,
                        request.CheckIDBandsSignature,
                        patient
                        );

                    await _context.CheckIdBandTests.AddAsync(idBandRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(idBandRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
