using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Visits.Commands
{
    public class EditVisitCommand : IRequest<Result<int>>
    {
        public int VisitId { get; set; }

        public int PatientId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ProblemDescription { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }
    }

    public class EditVisitCommandHandler : IRequestHandler<EditVisitCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public EditVisitCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(EditVisitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var visit = await _context.PatientVisits.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.VisitId, cancellationToken);
                if (visit == null)
                    throw new Exception("This visitation does not exist");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient does not exist");

                visit.Set(
                request.StartDate,
                request.EndDate,
                request.ProblemDescription,
                request.Address,
                request.City,
                request.PostalCode,
                request.Province,
                patient);

                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(visit.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
