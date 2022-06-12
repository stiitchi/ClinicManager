using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Commands
{
    public class Add24HourIntakeCommand : IRequest<Result<int>>
    {
        public int Intake24Hour { get; set; }
        public int Output24Hour { get; set; }
        public int TotalIntake { get; set; }
        public int PatientId { get; set; }
        public DateTime DateToday { get; set; }

    }

    public class Add24HourIntakeCommandHandler : IRequestHandler<Add24HourIntakeCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public Add24HourIntakeCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(Add24HourIntakeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var intake24Hour = await _context.Previous24HourIntakeTests.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                if (intake24Hour != null)
                    throw new Exception("24 Hour Intake already exists");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exists");

                var prev24HourIntake = new Previous24HourIntakeEntity(
                   request.Intake24Hour,
                   request.Output24Hour,
                   request.TotalIntake,
                   request.DateToday,
                   patient
                    );

                await _context.Previous24HourIntakeTests.AddAsync(prev24HourIntake, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(prev24HourIntake.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
