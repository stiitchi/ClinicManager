using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanSkinIntegrity;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.SkinReport.Commands
{
    public class AddSkinIntegrityReportCommand : IRequest<Result<int>>
    {
        public string Sacrum { get; set; }
        public string Hips { get; set; }
        public string Heals { get; set; }
        public string Other { get; set; }
        public string Comments { get; set; }
        public int PatientId { get; set; }
        public int SkinIntegrityId { get; set; }
    }

    public class AddSkinIntegrityReportCommandHandler : IRequestHandler<AddSkinIntegrityReportCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddSkinIntegrityReportCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddSkinIntegrityReportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var skinIntegrities = await _context.SkinIntegrityReports.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.SkinIntegrityId, cancellationToken);
                if (skinIntegrities != null)
                    throw new Exception("Skin Integrity already exists");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var skinIntegrity = new SkinIntegrityReport(
                    request.Sacrum,
                    request.Hips,
                    request.Heals,
                    request.Other,
                    request.Comments,
                    patient
                    );

                await _context.SkinIntegrityReports.AddAsync(skinIntegrity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(skinIntegrity.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
