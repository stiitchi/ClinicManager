using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Doctor.Commands
{
    public class DeleteDoctorCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteDoctorCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {

            var user = await _context.Users.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(user.Id);

        }
    }
}
