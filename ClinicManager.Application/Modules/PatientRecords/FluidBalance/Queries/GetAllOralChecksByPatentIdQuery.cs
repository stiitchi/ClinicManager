using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using ClinicManager.Shared.DTO_s.Records.FluidBalance;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Queries
{
    public class GetAllOralInputChecksByPatentIdQuery : IRequest<Result<List<OralIntakeDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllOralInputChecksByPatentIdQueryHandler : IRequestHandler<GetAllOralInputChecksByPatentIdQuery, Result<List<OralIntakeDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllOralInputChecksByPatentIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<OralIntakeDTO>>> Handle(GetAllOralInputChecksByPatentIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<OralIntakeTestEntity, OralIntakeDTO>> expression = e => new OralIntakeDTO
                {
                    OralIntakeTestId = e.Id,
                    OralCheckType = e.OralCheckType,
                    OralIntakeVolume = e.OralIntakeVolume,
                    OralIntakeTime = e.OralIntakeTime,
                    OralIntakeMl = e.OralIntakeMl,
                    PatientId = e.PatientId
                };

                var oralInputChecks = await _context.OralIntakeTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Where(x => x.PatientId == request.PatientId && x.OralCheckType != null)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<OralIntakeDTO>>.SuccessAsync(oralInputChecks);

            }
            catch (Exception ex)
            {
                return await Result<List<OralIntakeDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
