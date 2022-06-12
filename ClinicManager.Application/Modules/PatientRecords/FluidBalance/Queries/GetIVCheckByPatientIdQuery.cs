using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Queries
{
    public class GetIVCheckByPatientIdQuery : IRequest<Result<FluidBalanceIVCheckDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetIVCheckByPatientIdQueryHandler : IRequestHandler<GetIVCheckByPatientIdQuery, Result<FluidBalanceIVCheckDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetIVCheckByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<FluidBalanceIVCheckDTO>> Handle(GetIVCheckByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var ivCheck = await _context.IVTestRecords.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);

                if (ivCheck == null)
                    throw new Exception("Unable to return IV Check");
                var dto = new FluidBalanceIVCheckDTO
                {
                    IVTestId = ivCheck.Id,
                    intravenousML = ivCheck.IntravenousIntakeMl,
                    intravenousIntakeTime = ivCheck.IntravenousIntakeTime,
                    intravenousIntakeTimeCompleted = ivCheck.IntravenousIntakeTimeCompleted,
                    intravenousStartVolume = ivCheck.IntravenousIntakeStartVolume,
                    intravenousCompleteVolume = ivCheck.IntravenousIntakeCompleteVolume,
                    intravenousCheck = ivCheck.IvCheck,
                    intravenousDesc = ivCheck.IvDescription,
                    intravenousRunningTotal = ivCheck.IntravenousRunningTotal,
                    PatientId = ivCheck.PatientId
                };
                return await Result<FluidBalanceIVCheckDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<FluidBalanceIVCheckDTO>.FailAsync(ex.Message);
            }
        }
    }
}
