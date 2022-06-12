using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Commands
{
   public class DeleteNPORecordCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteNPORecordCommandHandler : IRequestHandler<DeleteNPORecordCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteNPORecordCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteNPORecordCommand request, CancellationToken cancellationToken)
        {

            var npoEntry = await _context.KeepNPOTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.KeepNPOTests.Remove(npoEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(npoEntry.Id);

        }
    }
}
