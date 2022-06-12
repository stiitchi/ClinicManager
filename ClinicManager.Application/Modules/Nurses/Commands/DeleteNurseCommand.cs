using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace ClinicManager.Application.Modules.Nurses.Commands
{
    public class DeleteNurseCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteNurseCommandHandler : IRequestHandler<DeleteNurseCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteNurseCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteNurseCommand request, CancellationToken cancellationToken)
        {

            var user = await _context.Users.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(user.Id);

        }
    }
}
