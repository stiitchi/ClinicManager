using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Commands
{
    public class AddOralIntakeTestCommand : IRequest<Result<int>>
    {
        public int PatientId { get; set; }
        public int OralIntakeMl { get; set; }
        public int OralIntakeVolume { get; set; }
        public int RunningTotalOral { get; set; }
        public string OralCheckType { get; set; }
        public DateTime OralIntakeTime { get; set; }
    }

    public class AddOralIntakeTestCommandHandler : IRequestHandler<AddOralIntakeTestCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddOralIntakeTestCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddOralIntakeTestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var oralTest = await _context.OralTests.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                if (oralTest != null)
                    throw new Exception("Oral Test already exists");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient != null)
                    throw new Exception("Patient already exists");

                var oralTests = new OralIntakeTestEntity(
                   request.OralIntakeMl,
                   request.OralIntakeTime,
                   request.OralIntakeVolume,
                   request.RunningTotalOral,
                   request.OralCheckType,            
                   patient
                    );

                await _context.OralIntakeTests.AddAsync(oralTests, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(oralTest.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
