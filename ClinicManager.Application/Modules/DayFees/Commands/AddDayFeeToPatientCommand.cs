using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.DayFeesAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.DayFees.Commands
{
   public class AddPatientDayFeeCommand : IRequest<Result<int>>
    {
        public int PatientDayFeeId { get; set; }
        public int DayFeeId { get; set; }
        public int PatientId { get; set; }
    }

    public class AddPatientDayFeeCommandHandler : IRequestHandler<AddPatientDayFeeCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddPatientDayFeeCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddPatientDayFeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var patientDayFees = await _context.PatientDayFees.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientDayFeeId, cancellationToken);
                if (patientDayFees != null)
                    throw new Exception("Patient is already assigned to this Day Fee");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var dayFees = await _context.DayFees.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.DayFeeId, cancellationToken);
                if (dayFees == null)
                    throw new Exception("Day Fee doesn't exist");

                var patientICDCode = new PatientDayFeesEntity(
                    patient,
                    dayFees
                    );

                await _context.PatientDayFees.AddAsync(patientICDCode, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(patientICDCode.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
