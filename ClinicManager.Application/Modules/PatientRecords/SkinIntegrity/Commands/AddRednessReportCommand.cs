using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Domain.Entities.PatientAggregate.Records.SkinIntegrity;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.SkinIntegrity.Commands
{
       public class AddRednessReportCommand : IRequest<Result<int>>
       {
        public DateTime ReportRednessTime { get; set; }
        public int ReportRednessFrequency { get; set; }
        public int ReportRednessId { get; set; }
        public string ReportRednessSignature { get; set; }
        public int PatientId { get; set; }


        public class AddRednessReportCommandHandler : IRequestHandler<AddRednessReportCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddRednessReportCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddRednessReportCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var rednessEntry = await _context.RednessTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.Id == request.ReportRednessId
                                                     ,cancellationToken);
                    if (rednessEntry != null)
                        throw new Exception("Redness already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var redness = new RednessEntity(
                        request.ReportRednessTime,
                        request.ReportRednessFrequency,
                        request.ReportRednessSignature,
                        patient
                        );

                    await _context.RednessTests.AddAsync(redness, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(redness.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
