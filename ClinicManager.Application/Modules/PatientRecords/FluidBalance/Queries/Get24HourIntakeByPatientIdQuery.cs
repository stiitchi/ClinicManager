using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Queries
{
    public class Get24HourIntakeByPatientIdQuery : IRequest<Result<Previous24HourIntakeDTO>>
    {
        public int PatientId { get; set; }
    }

    public class Get24HourIntakeByPatientIdQueryHandler : IRequestHandler<Get24HourIntakeByPatientIdQuery, Result<Previous24HourIntakeDTO>>
    {
        private readonly IApplicationDbContext _context;

        public Get24HourIntakeByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<Previous24HourIntakeDTO>> Handle(Get24HourIntakeByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var prev24HourCheck = await _context.Previous24HourIntakeTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .Where(x => x.Previous24HourOutput != 0 && x.Previous24HourIntake != 0)
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);

                if (prev24HourCheck == null)
                    throw new Exception("Unable to return 24 Hour Check");
                var dto = new Previous24HourIntakeDTO
                {
                    TotalIntakeId = prev24HourCheck.Id,
                    DateToday = prev24HourCheck.DateToday,
                    TotalIntake = prev24HourCheck.Total24HourIntake,
                    Output24Hour = prev24HourCheck.Previous24HourOutput,
                    Intake24Hour = prev24HourCheck.Previous24HourIntake,
                    PatientId = prev24HourCheck.PatientId
                };
                return await Result<Previous24HourIntakeDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<Previous24HourIntakeDTO>.FailAsync(ex.Message);
            }
        }
    }
}
