using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Psychological.Commands
{
    public class DeleteHealthEducationCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteHealthEducationCommandHandler : IRequestHandler<DeleteHealthEducationCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteHealthEducationCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteHealthEducationCommand request, CancellationToken cancellationToken)
        {

            var heatlhEducationEntry = await _context.HealthCareTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.HealthCareTests.Remove(heatlhEducationEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(heatlhEducationEntry.Id);
        }
    }
}
