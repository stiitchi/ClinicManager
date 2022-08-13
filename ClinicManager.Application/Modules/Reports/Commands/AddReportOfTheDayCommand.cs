using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Reports.Commands
{
    public class AddReportOfTheDayCommand : IRequest<Result<int>>
    {
        public int PatientId { get; set; }
    }

    public class AddReportOfTheDayCommandHandler : IRequestHandler<AddReportOfTheDayCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddReportOfTheDayCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddReportOfTheDayCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var patients = await _context.Patients.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patients != null)
                    throw new Exception("Patient already exists");

                var now = DateTime.Now;
                var dateToday = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                var dateTomorrow = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).AddDays(1);


                var reportOfTheDay = await _context.ReportOfTheDayRecords.IgnoreQueryFilters()
                                             .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);

                //Records
                var comfortSleepRecords = await _context.NurseCarePlanComfortSleepRecords.IgnoreQueryFilters()
                                  .Where(x => x.PainControlTime >= dateToday && x.PainControlTime <= dateTomorrow)
                                  .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);

                var progressNotes = await _context.PatientProgressTests.IgnoreQueryFilters()
                                             .Where(x => x.DateAdded >= dateToday && x.DateAdded <= dateTomorrow)
                                             .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);

                var dailyCareRecords = await _context.DailyCareRecords.IgnoreQueryFilters()
                                      .Where(x => x.DateAdded >= dateToday && x.DateAdded <= dateTomorrow)
                                      .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);

                var patient = await _context.Patients.IgnoreQueryFilters()
                               .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);

                #region Elimination

                foreach(var record in patient.CathetherRecords)
                {
                  var cathetherRecords = await _context.CathetherRecords.IgnoreQueryFilters()
                 .Where(x => x.CathetherTime >= dateToday && x.CathetherTime <= dateTomorrow)
                 .FirstOrDefaultAsync(c => c.Id == record.Id, cancellationToken);
                }
                foreach (var record in patient.ContinentRecords)
                {
                    var cathetherRecords = await _context.ContinentRecords.IgnoreQueryFilters()
                   .Where(x => x.ContinentTime >= dateToday && x.ContinentTime <= dateTomorrow)
                   .FirstOrDefaultAsync(c => c.Id == record.Id, cancellationToken);
                }

                #endregion

                //var fluidBalanceRecords = await _context.Previous24HourIntakeTests.IgnoreQueryFilters()
                //           .Where(x => x.DateToday >= dateToday && x.DateToday <= dateTomorrow)
                //           .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);


                await _context.PatientProgressTests.AddAsync(progressNotes, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(progressNotes.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
