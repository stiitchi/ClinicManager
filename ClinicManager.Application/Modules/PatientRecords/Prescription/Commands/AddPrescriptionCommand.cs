using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Prescription;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Prescription.Commands
{
    public class AddPrescriptionCommand : IRequest<Result<int>>
    {
        public int PrescriptionId { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public string MedicationName { get; set; }
        public double Dose { get; set; }
        public double Freq { get; set; }
        public string Route { get; set; }
        public double DurationOfQuantity { get; set; }
        public bool ReqWS { get; set; }
        public double ReqQuantity { get; set; }
        public DateTime ReqDate { get; set; }
        public double PharQuantity { get; set; }
        public DateTime PharDate { get; set; }


        public class AddPrescriptionCommandHandler : IRequestHandler<AddPrescriptionCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddPrescriptionCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddPrescriptionCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var prescriptions = await _context.Prescriptions.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.Id == request.PrescriptionId, cancellationToken);
                    if (prescriptions != null)
                        throw new Exception("Prescription Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var prescription = new PrescriptionEntity(
                        request.MedicationName,
                        request.Dose,
                        request.Freq,
                        request.Route,
                        request.DurationOfQuantity,
                        request.ReqWS,
                        request.ReqQuantity,
                        request.PharQuantity,
                        request.Date,
                        request.ReqDate,
                        request.PharDate,
                        patient
                        );

                    await _context.Prescriptions.AddAsync(prescription, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(prescription.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
