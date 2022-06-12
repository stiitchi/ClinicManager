using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Queries
{
    public class GetAllOralChecksByPatentIdQuery : IRequest<Result<List<FluidBalanceRecordOralCheckDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllOralChecksByPatentIdQueryHandler : IRequestHandler<GetAllOralChecksByPatentIdQuery, Result<List<FluidBalanceRecordOralCheckDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllOralChecksByPatentIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<FluidBalanceRecordOralCheckDTO>>> Handle(GetAllOralChecksByPatentIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<OralIntakeTestEntity, FluidBalanceRecordOralCheckDTO>> expression = e => new FluidBalanceRecordOralCheckDTO
                {
                    OralCheckType = e.OralCheckType,
                    IsUrine = e.IsUrine,
                    OutputMl = e.OutputMl,
                    OralIntakeVolume = e.OralIntakeVolume,
                    OralIntakeTime = e.OralIntakeTime,
                    OralIntakeMl = e.OralIntakeMl,
                    OralTestId = e.Id,
                    PatientId = e.PatientId
                };

                var oralChecks = await _context.OralIntakeTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Where(x => x.PatientId == request.PatientId && x.OralCheckType != null)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<FluidBalanceRecordOralCheckDTO>>.SuccessAsync(oralChecks);

            }
            catch (Exception ex)
            {
                return await Result<List<FluidBalanceRecordOralCheckDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
