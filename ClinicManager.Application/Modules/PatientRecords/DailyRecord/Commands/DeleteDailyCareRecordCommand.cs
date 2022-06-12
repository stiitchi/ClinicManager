using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.DailyRecord.Commands
{ 
   public class DeleteDailyCareRecordCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDailyCareRecordCommandHandler : IRequestHandler<DeleteDailyCareRecordCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteDailyCareRecordCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteDailyCareRecordCommand request, CancellationToken cancellationToken)
        {

            var dailyCareRecord = await _context.DailyCareRecords.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.DailyCareRecords.Remove(dailyCareRecord);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(dailyCareRecord.Id);

        }
    }
}
