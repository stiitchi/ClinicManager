using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.ComfortSleep.Commands
{
     public class DeleteComfortSleepRecordCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteComfortSleepRecordCommandHandler : IRequestHandler<DeleteComfortSleepRecordCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteComfortSleepRecordCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteComfortSleepRecordCommand request, CancellationToken cancellationToken)
        {

            var comfortSleepRecords = await _context.NurseCarePlanComfortSleepRecords.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.NurseCarePlanComfortSleepRecords.Remove(comfortSleepRecords);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(comfortSleepRecords.Id);

        }
    }
}
