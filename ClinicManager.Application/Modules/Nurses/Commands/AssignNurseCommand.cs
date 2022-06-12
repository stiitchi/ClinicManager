using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Nurses.Commands
{
  public class AssignNurseCommand : IRequest<Result<int>>
    {
        public int NurseId { get; set; }
        public int PatientId { get; set; }
    }

    public class AssignNurseCommandHandler : IRequestHandler<AssignNurseCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AssignNurseCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AssignNurseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var nurse = await _context.Users.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.NurseId == request.NurseId, cancellationToken);
                if (nurse == null)
                    throw new Exception("User is not a Nurse");

                var patient = await _context.Users.IgnoreQueryFilters()
                                       .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("User is not a Patient");

                if (patient != null)
                {
                    patient.AssignNurseToPatient(nurse.Id, patient.Id);
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
