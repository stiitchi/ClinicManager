using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Problems;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientProblems.Commands
{
    public class AddPatientProblemCommand : IRequest<Result<int>>
    {
        public int ProblemId { get; set; }

        public int PatientId { get; set; }

        public string Description { get; set; }

        public DateTime OnSetDate { get; set; }
    }

    public class AddPatientProblemCommandHandler : IRequestHandler<AddPatientProblemCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddPatientProblemCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddPatientProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var patientProblems = await _context.PatientProblems.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.ProblemId, cancellationToken);
                if (patientProblems == null)
                    throw new Exception("Patient problem doesn't exist");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var patientDayFee = new PatientProblemsEntity(
                    request.Description,
                    request.OnSetDate,
                    patient
                    );

                await _context.PatientProblems.AddAsync(patientDayFee, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(patientDayFee.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
