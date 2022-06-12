using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Queries
{
    public class GetOralCheckByPatientIdQuery : IRequest<Result<FluidBalanceRecordOralCheckDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetOralCheckByPatientIdQueryHandler : IRequestHandler<GetOralCheckByPatientIdQuery, Result<FluidBalanceRecordOralCheckDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetOralCheckByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<FluidBalanceRecordOralCheckDTO>> Handle(GetOralCheckByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var oralCheck = await _context.OralIntakeTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .Where(x => x.OralCheckType != null)
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);

                if (oralCheck == null)
                    throw new Exception("Unable to return Oral Check");
                var dto = new FluidBalanceRecordOralCheckDTO
                {
                    OralTestId = oralCheck.Id,
                    OralIntakeMl = oralCheck.OralIntakeMl,
                    OralIntakeTime = oralCheck.OralIntakeTime,
                    OralIntakeVolume = oralCheck.OralIntakeVolume,
                    OutputMl = oralCheck.OutputMl,
                    IsUrine = oralCheck.IsUrine,
                    PatientId = oralCheck.PatientId
                };
                return await Result<FluidBalanceRecordOralCheckDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<FluidBalanceRecordOralCheckDTO>.FailAsync(ex.Message);
            }
        }
    }
}
