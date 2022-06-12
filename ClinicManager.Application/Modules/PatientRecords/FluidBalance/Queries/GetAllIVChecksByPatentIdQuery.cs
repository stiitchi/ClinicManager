using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.FluidBalance.Queries
{
    public class GetAllIVChecksByPatentIdQuery : IRequest<Result<List<FluidBalanceIVCheckDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllIVChecksByPatentIdQueryHandler : IRequestHandler<GetAllIVChecksByPatentIdQuery, Result<List<FluidBalanceIVCheckDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllIVChecksByPatentIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<FluidBalanceIVCheckDTO>>> Handle(GetAllIVChecksByPatentIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<IVTestEntity, FluidBalanceIVCheckDTO>> expression = e => new FluidBalanceIVCheckDTO
                {
                    IVTestId = e.Id,
                    intravenousML = e.IntravenousIntakeMl,
                    intravenousIntakeTime = e.IntravenousIntakeTime,
                    intravenousIntakeTimeCompleted = e.IntravenousIntakeTimeCompleted,
                    intravenousStartVolume = e.IntravenousIntakeStartVolume,
                    intravenousCompleteVolume = e.IntravenousIntakeCompleteVolume,
                    intravenousCheck = e.IvCheck,
                    intravenousDesc = e.IvDescription,
                    intravenousRunningTotal = e.IntravenousRunningTotal,
                    PatientId = e.PatientId
                };

                var ivChecks = await _context.IVTestRecords
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Where(x => x.PatientId == request.PatientId)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<FluidBalanceIVCheckDTO>>.SuccessAsync(ivChecks);

            }
            catch (Exception ex)
            {
                return await Result<List<FluidBalanceIVCheckDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
