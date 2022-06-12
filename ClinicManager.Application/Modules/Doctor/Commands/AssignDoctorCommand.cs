using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Doctor.Commands
{
     public class AssignDoctorCommand : IRequest<Result<int>>
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }

    public class AssignDoctorCommandHandler : IRequestHandler<AssignDoctorCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AssignDoctorCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AssignDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var doctor = await _context.Users.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.DoctorId == request.DoctorId, cancellationToken);
                if (doctor == null)
                    throw new Exception("User is not a Doctor");

                var patient = await _context.Users.IgnoreQueryFilters()
                                       .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("User is not a Patient");

                if(patient != null)
                {
                    patient.AssignDoctorToPatient(doctor.Id, patient.Id);
                }

                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(patient.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
