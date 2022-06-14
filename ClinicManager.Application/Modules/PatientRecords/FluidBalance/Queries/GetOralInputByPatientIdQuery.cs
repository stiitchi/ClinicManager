using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.FluidBalance;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Queries
{
     public class GetOralInputByPatientIdQuery : IRequest<Result<OralIntakeDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetOralInputByPatientIdQueryHandler : IRequestHandler<GetOralInputByPatientIdQuery, Result<OralIntakeDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetOralInputByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<OralIntakeDTO>> Handle(GetOralInputByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var oralCheck = await _context.OralIntakeTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .Where(x => x.OralCheckType != null)
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);

                if (oralCheck == null)
                    throw new Exception("Unable to return Oral Check");
                var dto = new OralIntakeDTO
                {
                    OralIntakeTestId = oralCheck.Id,
                    OralIntakeMl = oralCheck.OralIntakeMl,
                    OralIntakeTime = oralCheck.OralIntakeTime,
                    OralIntakeVolume = oralCheck.OralIntakeVolume,
                    PatientId = oralCheck.PatientId
                };
                return await Result<OralIntakeDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<OralIntakeDTO>.FailAsync(ex.Message);
            }
        }
    }
}
