using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Commands
{
     public class DeleteSpecialRecordCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSpecialRecordCommandHandler : IRequestHandler<DeleteSpecialRecordCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSpecialRecordCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteSpecialRecordCommand request, CancellationToken cancellationToken)
        {

            var specialEntry = await _context.SpecialTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.SpecialTests.Remove(specialEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(specialEntry.Id);

        }
    }
}
