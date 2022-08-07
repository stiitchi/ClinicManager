using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Prescription;
using ClinicManager.Shared.DTO_s.Records.Prescription;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Prescription.Queries
{
    public class GetAllPrescriptionsByPatientIdQuery : IRequest<Result<List<PrescriptionDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllPrescriptionsByPatientIdQueryHandler : IRequestHandler<GetAllPrescriptionsByPatientIdQuery, Result<List<PrescriptionDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPrescriptionsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<PrescriptionDTO>>> Handle(GetAllPrescriptionsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PrescriptionEntity, PrescriptionDTO>> expression = e => new PrescriptionDTO
                {
                    PrescriptionId     = e.Id,
                    Date               = e.Date,
                    MedicationName     = e.MedicationName,
                    Dose               = e.Dose,
                    Route              = e.Route,
                    Freq               = e.Frequency,
                    DurationOfQuantity = e.DurationOfQuantity,
                    ReqDate            = e.ReqDate,
                    PharQuantity       = e.PharQuantity,
                    PharDate           = e.PharDate,
                    PatientId          = e.PatientId
                };

                var prescriptions = await _context.Prescriptions
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<PrescriptionDTO>>.SuccessAsync(prescriptions);

            }
            catch (Exception ex)
            {
                return await Result<List<PrescriptionDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
