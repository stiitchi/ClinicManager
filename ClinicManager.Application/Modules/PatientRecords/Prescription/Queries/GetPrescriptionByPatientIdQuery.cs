using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Prescription;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Prescription.Queries
{
    public class GetPrescriptionByPatientIdQuery : IRequest<Result<PrescriptionDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetPrescriptionByPatientIdQueryHandler : IRequestHandler<GetPrescriptionByPatientIdQuery, Result<PrescriptionDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetPrescriptionByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<PrescriptionDTO>> Handle(GetPrescriptionByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var prescription = await _context.Prescriptions.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId);
                if (prescription == null)
                    throw new Exception("Unable to return Prescription");

                var dto = new PrescriptionDTO
                {
                    PrescriptionId      = prescription.Id,
                    Date                = prescription.Date,
                    MedicationName      = prescription.MedicationName,
                    Dose                = prescription.Dose,
                    Route               = prescription.Route,
                    Freq                = prescription.Frequency,
                    DurationOfQuantity  = prescription.DurationOfQuantity,
                    ReqWS               = prescription.ReqWS,
                    ReqQuantity         = prescription.ReqQuantity,
                    ReqDate             = prescription.ReqDate,
                    PharQuantity        = prescription.PharQuantity,
                    PharDate            = prescription.PharDate,
                    PatientId           = prescription.PatientId
                };
                return await Result<PrescriptionDTO>.SuccessAsync(dto);

            }
            catch (Exception ex)
            {
                return await Result<PrescriptionDTO>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
