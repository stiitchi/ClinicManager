using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Commands
{
  public class AddMobileImmobileCommand : IRequest<Result<int>>
    {
        public DateTime MobileImmobileTime { get; set; }
        public int MobileImmobileFreq { get; set; }
        public string MobileImmobileSignature { get; set; }
        public int PatientId { get; set; }


        public class AddMobileImmobileCommandHandler : IRequestHandler<AddMobileImmobileCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddMobileImmobileCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddMobileImmobileCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var mobileImmobileEntry = await _context.MobileImmobileTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (mobileImmobileEntry != null)
                        throw new Exception("Mobility Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var mobilityEntry = new MobileImmobileEntity(
                        request.MobileImmobileTime,
                        request.MobileImmobileFreq,
                        request.MobileImmobileSignature,
                        patient
                        );

                    await _context.MobileImmobileTests.AddAsync(mobilityEntry, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(mobilityEntry.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }  
}
