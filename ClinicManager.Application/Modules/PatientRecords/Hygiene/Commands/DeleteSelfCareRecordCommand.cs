using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Commands
{
    public class DeleteSelfCareRecordCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSelfCareRecordCommandHandler : IRequestHandler<DeleteSelfCareRecordCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSelfCareRecordCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteSelfCareRecordCommand request, CancellationToken cancellationToken)
        {

            var selfCareRecord = await _context.SelfCareTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.SelfCareTests.Remove(selfCareRecord);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(selfCareRecord.Id);

        }
    }
}
