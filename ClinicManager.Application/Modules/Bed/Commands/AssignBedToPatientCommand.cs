using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.BedAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Bed.Commands
{
    public class AssignBedToPatientCommand : IRequest<Result<int>>
    {
        public int PatientBedId { get; set; }
        public int BedId { get; set; }
        public int WardId { get; set; }
        public int RoomId { get; set; }
        public int PatientId { get; set; }
    }

    public class AssignBedToPatientCommandHandler : IRequestHandler<AssignBedToPatientCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AssignBedToPatientCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AssignBedToPatientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ward = await _context.Wards.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.WardId, cancellationToken);
                if (ward == null)
                    throw new Exception("Ward doesn't exist");

                var room = await _context.Wards.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.RoomId, cancellationToken);
                if (room == null)
                    throw new Exception("Room doesn't exist");

                var bed = await _context.Beds.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.BedId, cancellationToken);
                if (bed == null)
                    throw new Exception("Bed doesn't exist");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var patientBeds = await _context.PatientBeds.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientBedId && c.PatientId != request.PatientId, cancellationToken);

                if (patientBeds != null)
                    _context.PatientBeds.Remove(patientBeds);

                bed.AssignPatientToBed(patient);

                var patientName = $"{patient.Title} {patient.FirstName} {patient.LastName}";

                var patientBed = new PatientBedEntity(
                    patientName,
                    patient,
                    bed
                    );

                await _context.PatientBeds.AddAsync(patientBed, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(patientBed.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
