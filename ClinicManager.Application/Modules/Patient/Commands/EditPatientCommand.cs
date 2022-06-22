using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Patient.Commands
{
    public class EditPatientCommand : IRequest<Result<PatientDTO>>
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

    public class EditPatientCommandHandler : IRequestHandler<EditPatientCommand, Result<PatientDTO>>
    {
        private readonly IApplicationDbContext _context;

        public EditPatientCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<PatientDTO>> Handle(EditPatientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var patient = await _context.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient does not exist");
 
                patient.Set(
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

                await _context.SaveChangesAsync(cancellationToken);
                return await Result<PatientDTO>.SuccessAsync("Patient Added");
            }
            catch (Exception ex)
            {
                return await Result<PatientDTO>.FailAsync(ex.Message);
            }
        }
    }
}
