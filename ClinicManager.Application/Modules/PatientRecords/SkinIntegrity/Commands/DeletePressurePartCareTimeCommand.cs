using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.SkinIntegrity.Commands
{
    public class DeletePressurePartCareTimeCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePressurePartCareTimeCommandHandler : IRequestHandler<DeletePressurePartCareTimeCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public DeletePressurePartCareTimeCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(DeletePressurePartCareTimeCommand request, CancellationToken cancellationToken)
        {

            var pressureCareTimeEntry = await _context.PressurePartRecords.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            _context.PressurePartRecords.Remove(pressureCareTimeEntry);
            await _context.SaveChangesAsync(cancellationToken);
            return await Result<int>.SuccessAsync(pressureCareTimeEntry.Id);

        }
    }
}
