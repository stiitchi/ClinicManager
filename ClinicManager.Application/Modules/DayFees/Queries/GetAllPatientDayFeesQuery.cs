using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.DayFeesAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.DayFees.Queries
{
    public class GetAllPatientDayFeesQuery : IRequest<Result<List<PatientDayFeeDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllPatientDayFeesQueryHandler : IRequestHandler<GetAllPatientDayFeesQuery, Result<List<PatientDayFeeDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPatientDayFeesQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<PatientDayFeeDTO>>> Handle(GetAllPatientDayFeesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PatientDayFeesEntity, PatientDayFeeDTO>> expression = e => new PatientDayFeeDTO
                {
                    PatientDayFeeId = e.Id,
                    DayFeeId = e.DayFeesId.ToString(),
                    PatientId = e.PatientId,
                    DayFeeCode = e.DayFeeCode,
                    DayFeeDescription = e.DayFeeDescription
                };

                var dayFees = await _context.PatientDayFees
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Where(x => x.PatientId == request.PatientId)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<PatientDayFeeDTO>>.SuccessAsync(dayFees);

            }
            catch (Exception ex)
            {
                return await Result<List<PatientDayFeeDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
