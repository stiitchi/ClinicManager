using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Commands
{
    public class DeleteBedBathAssistCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteBedBathAssistCommandHandler : IRequestHandler<DeleteBedBathAssistCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBedBathAssistCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeleteBedBathAssistCommand request, CancellationToken cancellationToken)
        {

            var bedBathAssist = await _context.BedBathAssistTests.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.BedBathAssistTests.Remove(bedBathAssist);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(bedBathAssist.Id);

        }
    }
}
