using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Elimination.Commands
{
     public class DeleteCathetherCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCathetherCommandHandler : IRequestHandler<DeleteCathetherCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCathetherCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteCathetherCommand request, CancellationToken cancellationToken)
        {

            var cathetherRecord = await _context.CathetherRecords.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.CathetherRecords.Remove(cathetherRecord);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(cathetherRecord.Id);

        }
    }
}
