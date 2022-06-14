using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Intervention.Commands
{
  public class AddWoundCareCommand : IRequest<Result<int>>
    {
        public DateTime WoundCareTime { get; set; }
        public int WoundCareFreq { get; set; }
        public int WoundCareId { get; set; }
        public string WoundCareSignature { get; set; }
        public int PatientId { get; set; }


        public class AddWoundCareCommandHandler : IRequestHandler<AddWoundCareCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddWoundCareCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddWoundCareCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var woundCares = await _context.WoundCareTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.Id == request.WoundCareId, cancellationToken);
                    if (woundCares != null)
                        throw new Exception("Intervention Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var woundCare = new WoundCareEntity(
                        request.WoundCareTime,
                        request.WoundCareFreq,
                        request.WoundCareSignature,
                        patient
                        );

                    await _context.WoundCareTests.AddAsync(woundCare, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(woundCare.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
