using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Elimination.Commands
{
    public class DeleteContinentCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteComfortSleepRecordCommandHandler : IRequestHandler<DeleteContinentCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteComfortSleepRecordCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteContinentCommand request, CancellationToken cancellationToken)
        {

            var continentRecord = await _context.ContinentRecords.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.ContinentRecords.Remove(continentRecord);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(continentRecord.Id);

        }
    }
}
