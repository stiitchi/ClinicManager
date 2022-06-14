using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Commands
{
     public class AddOralOutputCommand : IRequest<Result<int>>
    {
        public int PatientId { get; set; }
        public int OralIOutputMl { get; set; }
        public int OralOutputTestId { get; set; }
        public bool IsUrine { get; set; }
        public int RunningTotalOralOutput { get; set; }
        public DateTime OralOutputTime { get; set; }
    }

    public class AddOralOutputCommandHandler : IRequestHandler<AddOralOutputCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddOralOutputCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddOralOutputCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var oralTest = await _context.OralTests.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                if (oralTest != null)
                    throw new Exception("Oral Test already exists");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient != null)
                    throw new Exception("Patient already exists");

                var oralTests = new OralOutputEntity(
                   request.OralIOutputMl,
                   request.OralOutputTime,
                   request.IsUrine,
                   request.RunningTotalOralOutput,
                   patient
                    );

                await _context.OralOutputTests.AddAsync(oralTests, cancellationToken);
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
