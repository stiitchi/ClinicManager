using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.DailyCare;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.DailyRecord.Commands
{
    public class AddDailyCareRecordCommand : IRequest<Result<int>>
    {
        public int DailyCareRecordId { get; set; }
        public int PatientId { get; set; }
        public string CareRecord { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime TimeAdded { get; set; }
    }

    public class AddDailyCareRecordCommandHandler : IRequestHandler<AddDailyCareRecordCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddDailyCareRecordCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddDailyCareRecordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dailyCareRecords = await _context.DailyCareRecords.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.DailyCareRecordId && c.Id == request.DailyCareRecordId);
                if (dailyCareRecords != null)
                    throw new Exception("Daily Record already exists");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Daily Record already exists");

                var dailyCareRecord = new DailyCareRecordEntity(
                   request.DateAdded,
                   request.TimeAdded,
                   request.CareRecord,
                   patient
                    );

                await _context.DailyCareRecords.AddAsync(dailyCareRecord, cancellationToken);
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
