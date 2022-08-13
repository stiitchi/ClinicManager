using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Vitals;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientVitals.Commands
{
    public class AddPatientVitalSignCommand : IRequest<Result<int>>
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

    public class AddPatientVitalSignCommandHandler : IRequestHandler<AddPatientVitalSignCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddPatientVitalSignCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddPatientVitalSignCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vitals = await _context.PatientVitals.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.VitalSignId, cancellationToken);
                if (vitals == null)
                    throw new Exception("Vital Sign doesn't exist");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var vital = new PatientVitalEntity(
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

                await _context.PatientVitals.AddAsync(vital, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(vital.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
