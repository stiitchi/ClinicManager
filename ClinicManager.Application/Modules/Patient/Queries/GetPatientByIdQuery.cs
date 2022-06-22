using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Patient.Queries
{
  public class GetPatientByIdQuery : IRequest<Result<PatientDTO>>
    {
        public int Id { get; set; }
    }

    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Result<PatientDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetPatientByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<PatientDTO>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var patient = await _context.Patients.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (patient == null)
                    throw new Exception("Unable to return Patient");
                var dto = new PatientDTO
                {
                    Id = patient.Id,
                    IDNo = patient.IDNo,
                    Title = patient.Title,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    DateOfBirth = patient.DateOfBirth,
                    AccountNo = patient.AccountNO,
                    AdmissionDate = patient.AdmissionDate,
                    DischargeDate = patient.DischargeDate,
                    ReportDate = patient.ReportDate,
                    WardNo = patient.WardNO,
                    BedNo = patient.BedNO,
                    EmergencyContactIdNo = patient.EmergencyContactIdNo,
                    EmergencyContactFirstName = patient.EmergencyContactFirstName,
                    EmergencyContactLastName = patient.EmergencyContactLastName,
                    EmergencyContactNo = patient.EmergencyContactNo,
                    Relationship = patient.Relationship,
                    RefferingDoctor = patient.RefferingDoctor,
                    RefferingHospital = patient.RefferingHospital,
                    MedicalAidName = patient.MedicalAidName,
                    MedicalAidNo = patient.MedicalAidNo,
                    MedicalAidOption = patient.MedicalAidOption,
                    OT = patient.Ot,
                    Speech = patient.SpeechLanguage,
                    Psych = patient.Psychologist,
                    Dietician = patient.Dietician,
                    SocialWorker = patient.SocialWorker,
                    Physio = patient.Physio,
                    DependentCode = patient.DependentCode,
                    Gender = patient.Gender,
                    Language = patient.Language,
                    Location = patient.Location,
                    Race = patient.Race,
                    Stage = patient.Stage         
                };
                return await Result<PatientDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<PatientDTO>.FailAsync(ex.Message);
            }
        }
    }
}
