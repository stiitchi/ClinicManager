using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.FluidBalance;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Queries
{
    public class GetOralOutputByPatientIdQuery : IRequest<Result<OralOutputDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetOralOutputByPatientIdQueryHandler : IRequestHandler<GetOralOutputByPatientIdQuery, Result<OralOutputDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetOralOutputByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<OralOutputDTO>> Handle(GetOralOutputByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var oralCheck = await _context.OralOutputTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);

                if (oralCheck == null)
                    throw new Exception("Unable to return Oral Check");
                var dto = new OralOutputDTO
                {
                    OralOutputTestId        = oralCheck.Id,
                    OralOutputMl            = oralCheck.OutputMl,
                    OralOutputTime          = oralCheck.OralOutputTime,
                    RunningOutputTotal      = oralCheck.RunningOutputTotal,
                    IsUrine                 = oralCheck.IsUrine,
                    PatientId               = oralCheck.PatientId
                };
                return await Result<OralOutputDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<OralOutputDTO>.FailAsync(ex.Message);
            }
        }
    }
}
