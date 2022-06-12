using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Admissions.Commands
{
    public class DeleteAdmissionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteAdmissionCommandHandler : IRequestHandler<DeleteAdmissionCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAdmissionCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteAdmissionCommand request, CancellationToken cancellationToken)
        {

            var admission = await _context.Admissions.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.Admissions.Remove(admission);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(admission.Id);

        }
    }
}
