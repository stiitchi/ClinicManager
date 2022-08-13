using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientVitals.Commands
{
    public class EditPatientVitalSignCommand : IRequest<Result<int>>
    {
        public int VitalSignId { get; set; }
        public int PatientId { get; set; }
        public string Temperature { get; set; }
        public string BloodPressure { get; set; }
        public string Pulse { get; set; }
        public string RespitoryRate { get; set; }
        public string BloodSaturation { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BodyMassIndex { get; set; }
        public DateTime LastTime { get; set; }
    }

    public class EditPatientVitalSignCommandHandler : IRequestHandler<EditPatientVitalSignCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public EditPatientVitalSignCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(EditPatientVitalSignCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vitalSign = await _context.PatientVitals.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.VitalSignId, cancellationToken);
                if (vitalSign == null)
                    throw new Exception("This vital sign does not exist");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient does not exist");

                vitalSign.Set(
                request.Temperature,
                request.BloodPressure,
                request.Pulse,
                request.RespitoryRate,
                request.BloodSaturation,
                request.Height,
                request.Weight,
                request.BodyMassIndex,
                request.LastTime,
                patient
                );

                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(vitalSign.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
