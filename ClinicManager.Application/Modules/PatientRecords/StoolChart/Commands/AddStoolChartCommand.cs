using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.StoolCharts;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.StoolChart.Commands
{
    public class AddStoolChartCommand : IRequest<Result<int>>
    {
        public int StoolChartId { get; set; }
        public int PatientId { get; set; }
        public bool NormalBowelMovement { get; set; }
        public bool Blood { get; set; }
        public int MuscousAmount { get; set; }
        public string BowelAmount { get; set; }
        public string Consistency { get; set; }
        public DateTime StoolTime { get; set; }
        public DateTime StoolDate { get; set; }
    }

    public class AddStoolChartCommandHandler : IRequestHandler<AddStoolChartCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddStoolChartCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddStoolChartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var stoolCharts = await _context.StoolChartTests.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.StoolChartId, cancellationToken);
                if (stoolCharts != null)
                    throw new Exception("Stool Chart already exists");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient already exists");

                var stoolChart = new StoolChartEntity(
                   patient,
                   request.NormalBowelMovement,
                   request.StoolTime,
                   request.StoolDate,
                   request.Blood,
                   request.MuscousAmount,
                   request.BowelAmount,
                   request.Consistency
                    );

                await _context.StoolChartTests.AddAsync(stoolChart, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(stoolChart.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
