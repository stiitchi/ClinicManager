using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.ComfortSleep;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.ComfortSleep.Commands
{
     public class AddComfortSleepRecordCommand : IRequest<Result<int>>
    {
        public DateTime PainControlTime { get; set; }
        public int Frequency { get; set; }
        public string Signature { get; set; }
        public int PatientId { get; set; }
        public int ComfortSleepRecordId { get; set; }
    }

    public class AddComfortSleepRecordCommandHandlers : IRequestHandler<AddComfortSleepRecordCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddComfortSleepRecordCommandHandlers(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddComfortSleepRecordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var comfortSleep = await _context.NurseCarePlanComfortSleepRecords.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.ComfortSleepRecordId && c.PatientId == request.PatientId
                                                 ,cancellationToken);
                if (comfortSleep != null)
                    throw new Exception("Report already exists");

                var patient = await _context.Patients.IgnoreQueryFilters()
                                               .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var comfortSleepReport = new NurseCarePlanComfortSleepEntity(
                   request.PainControlTime,
                   request.Frequency,
                   request.Signature,
                   patient
                    );

                await _context.NurseCarePlanComfortSleepRecords.AddAsync(comfortSleepReport, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(comfortSleepReport.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}

