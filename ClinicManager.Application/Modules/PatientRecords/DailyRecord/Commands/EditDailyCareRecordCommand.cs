using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.DailyRecord.Commands
{
    public class EditDailyCareRecordCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string CareRecord { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime TimeAdded { get; set; }
    }

    public class EditDailyCareRecordCommandHandler : IRequestHandler<EditDailyCareRecordCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public EditDailyCareRecordCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(EditDailyCareRecordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dailyCareRecord = await _context.DailyCareRecords.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                if (dailyCareRecord != null)
                    throw new Exception("Daily Record already exists");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient != null)
                    throw new Exception("Daily Record already exists");

                dailyCareRecord.Set(
                   request.DateAdded,
                   request.TimeAdded,
                   request.CareRecord,
                   patient
                    );

                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(dailyCareRecord.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
