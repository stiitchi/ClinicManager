using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Commands
{
    public class DeleteBedBathRecordCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteBedBathRecordCommandHandler : IRequestHandler<DeleteBedBathRecordCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBedBathRecordCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteBedBathRecordCommand request, CancellationToken cancellationToken)
        {

            var hygieneRecord = await _context.BedBathTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.BedBathTests.Remove(hygieneRecord);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(hygieneRecord.Id);

        }
    }
}