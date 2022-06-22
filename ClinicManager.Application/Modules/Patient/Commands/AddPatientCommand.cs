using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Patient.Commands
{
     public class AddPatientCommand : IRequest<Result<int>>
    {
        public int PatientId { get; set; }
        public int AccountNo { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public DateTime ReportDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int IDNo { get; set; }
        public int WardNo { get; set; }
        public int BedNo { get; set; }
        public string Location { get; set; }
        public string Stage { get; set; }
        public string Language { get; set; }
        public string Gender { get; set; }
        public string Relationship { get; set; }
        public string RefferingDoctor { get; set; }
        public string RefferingHospital { get; set; }
        public int EmergencyContactNo { get; set; }
        public int EmergencyContactIdNo { get; set; }
        public string EmergencyContactFirstName { get; set; }
        public string EmergencyContactLastName { get; set; }
        public int MedicalAidNo { get; set; }
        public string MedicalAidName { get; set; }
        public string MedicalAidOption { get; set; }
        public string DependentCode { get; set; }
        public string Race { get; set; }
        public bool OT { get; set; }
        public bool Speech { get; set; }
        public bool Psych { get; set; }
        public bool Dietician { get; set; }
        public bool SocialWorker { get; set; }
        public bool Physio { get; set; }
    }

    public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddPatientCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var patients = await _context.Patients.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patients != null)
                    throw new Exception("Patient already exists");

                var patient = new PatientEntity(
                request.IDNo,
                request.Title,
                request.FirstName,
                request.LastName,
                request.DateOfBirth,
                request.AccountNo,
                request.AdmissionDate,
                request.DischargeDate,
                request.ReportDate,
                request.WardNo,
                request.BedNo,
                request.EmergencyContactIdNo,
                request.EmergencyContactFirstName,
                request.EmergencyContactLastName,
                request.Relationship,
                request.EmergencyContactNo,
                request.RefferingDoctor,
                request.RefferingHospital,
                request.MedicalAidName,
                request.MedicalAidNo,
                request.MedicalAidOption,
                request.DependentCode,
                request.OT,
                request.Speech,
                request.Psych,
                request.Dietician,
                request.SocialWorker,
                request.Physio,
                request.Location,
                request.Language,
                request.Stage,
                request.Gender,
                request.Race
                );
  
                await _context.Patients.AddAsync(patient, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(patient.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
