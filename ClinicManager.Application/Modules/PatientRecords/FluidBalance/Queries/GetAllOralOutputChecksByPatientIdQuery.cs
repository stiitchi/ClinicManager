using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using ClinicManager.Shared.DTO_s.Records.FluidBalance;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Queries
{ 
    public class GetAllOralOutputChecksByPatientIdQuery : IRequest<Result<List<OralOutputDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllOralOutputChecksByPatientIdQueryHandler : IRequestHandler<GetAllOralOutputChecksByPatientIdQuery, Result<List<OralOutputDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllOralOutputChecksByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<OralOutputDTO>>> Handle(GetAllOralOutputChecksByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<OralOutputEntity, OralOutputDTO>> expression = e => new OralOutputDTO
                {
                    OralOutputTestId         = e.Id,
                    IsUrine                  = e.IsUrine,
                    OralOutputMl             = e.OutputMl,
                    OralOutputTime           = e.OralOutputTime,
                    RunningOutputTotal       = e.RunningOutputTotal,
                    PatientId                = e.PatientId
                };

                var oralOutputChecks = await _context.OralOutputTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .OrderByDescending(x => x.OralOutputTime)
                        .Where(x => x.PatientId == request.PatientId)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<OralOutputDTO>>.SuccessAsync(oralOutputChecks);

            }
            catch (Exception ex)
            {
                return await Result<List<OralOutputDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
