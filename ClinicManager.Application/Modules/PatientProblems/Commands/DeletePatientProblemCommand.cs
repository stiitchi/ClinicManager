using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientProblems.Commands
{
    public class DeletePatientProblemCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePatientProblemCommandHandler : IRequestHandler<DeletePatientProblemCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeletePatientProblemCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeletePatientProblemCommand request, CancellationToken cancellationToken)
        {
            var problem = await _context.PatientProblems.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.PatientProblems.Remove(problem);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(problem.Id);
        }
    }
}
