using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Commands
{
    public class AddIVTestCommand : IRequest<Result<int>>
    {
        public int IVTestId { get; set; }
        public int PatientId { get; set; }
        public int OralTestId { get; set; }
        public int intravenousML { get; set; }
        public int intravenousStartVolume { get; set; }
        public int intravenousCompleteVolume { get; set; }
        public int intravenousRunningTotal { get; set; }
        public bool intravenousCheck { get; set; }
        public string intravenousDesc { get; set; }
        public string intravenousCheckType { get; set; }
        public DateTime intravenousIntakeTime { get; set; }
        public DateTime intravenousIntakeTimeCompleted { get; set; }
    }

    public class AddIVTestCommandHandler : IRequestHandler<AddIVTestCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddIVTestCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddIVTestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ivTest = await _context.IVTestRecords.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.IVTestId && c.PatientId == request.IVTestId, cancellationToken);
                if (ivTest != null)
                    throw new Exception("IV Test already exists");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient != null)
                    throw new Exception("Daily Record already exists");

                var ivTests = new IVTestEntity(
                   request.intravenousML,
                   request.intravenousIntakeTime,
                   request.intravenousIntakeTimeCompleted,
                   request.intravenousStartVolume,
                   request.intravenousCompleteVolume,
                   request.intravenousCheck,
                   request.intravenousDesc,
                   request.intravenousRunningTotal,
                   request.intravenousCheckType,
                   patient
                    );

                await _context.IVTestRecords.AddAsync(ivTests, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(ivTest.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
