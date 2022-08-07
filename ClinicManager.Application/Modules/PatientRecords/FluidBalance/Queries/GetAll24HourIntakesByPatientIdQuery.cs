using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Queries
{
    public class GetAll24HourIntakesByPatientIdQuery : IRequest<Result<List<Previous24HourIntakeDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAll24HourIntakesByPatientIdQueryHandler : IRequestHandler<GetAll24HourIntakesByPatientIdQuery, Result<List<Previous24HourIntakeDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAll24HourIntakesByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<Previous24HourIntakeDTO>>> Handle(GetAll24HourIntakesByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Previous24HourIntakeEntity, Previous24HourIntakeDTO>> expression = e => new Previous24HourIntakeDTO
                {
                    TotalIntakeId       = e.Id,
                    DateToday           = e.DateToday,
                    TotalIntake         = e.Total24HourIntake,
                    Output24Hour        = e.Previous24HourOutput,
                    Intake24Hour        = e.Previous24HourIntake,
                    PatientId           = e.PatientId
                };

                var prev24hour = await _context.Previous24HourIntakeTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .OrderByDescending(x => x.DateToday)
                        .Where(x=> x.PatientId == request.PatientId && x.Previous24HourOutput != 0 && x.Previous24HourIntake != 0)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<Previous24HourIntakeDTO>>.SuccessAsync(prev24hour);

            }
            catch (Exception ex)
            {
                return await Result<List<Previous24HourIntakeDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
