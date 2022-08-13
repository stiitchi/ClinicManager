using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Visits;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Visits.Commands
{
    public class AddVisitCommand : IRequest<Result<int>>
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

    public class AddVisitCommandHandler : IRequestHandler<AddVisitCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddVisitCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddVisitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var visits = await _context.PatientVisits.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.VisitId, cancellationToken);
                if (visits == null)
                    throw new Exception("Patient doesn't exist");

                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var visit = new VisitEntity(
                    request.StartDate,
                    request.EndDate,
                    request.ProblemDescription,
                    request.Address,
                    request.City,
                    request.PostalCode,
                    request.Province,
                    patient
                    );

                await _context.PatientVisits.AddAsync(visit, cancellationToken);
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
