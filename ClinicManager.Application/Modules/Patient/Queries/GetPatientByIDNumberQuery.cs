using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Patient.Queries
{
   public class GetPatientByIDNumberQuery : IRequest<Result<PatientDTO>>
    {
        public long PatientIDNumber { get; set; }
    }

    public class GetPatientByIDNumberQueryHandler : IRequestHandler<GetPatientByIDNumberQuery, Result<PatientDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetPatientByIDNumberQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<PatientDTO>> Handle(GetPatientByIDNumberQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var patient = await _context.Patients.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.IDNo == request.PatientIDNumber, cancellationToken);

                if (patient == null)
                    throw new Exception("Unable to return Patient");
                var dto = new PatientDTO
                {
                    Id = patient.Id,
                    WardNo = patient.WardNO,
                    BedNo = patient.BedNO,
                    CaseInformationNumber = patient.CaseInfomationNo,
                    AccountNo = patient.AccountNO,
                    AdmissionDate = patient.AdmissionDate,
                    DateOfBirth = patient.DateOfBirth,
                    DischargeDate = patient.DischargeDate,
                    ReportDate = patient.ReportDate,
                    Title = patient.Title,
                    Initials = patient.Initials,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    IDNo = patient.IDNo,
                    PatientTelNo = patient.PatientTelNo,
                    PatientCellNo = patient.PatientCellNo,
                    PatientWorkTelNo = patient.PatientWorkTelNo,
                    Email = patient.Email,
                    StreetAddress = patient.StreetAddress,
                    City = patient.City,
                    Province = patient.Province,
                    Suburb = patient.Suburb,
                    PostalCode = patient.PostalCode,
                    PoBox = patient.PoBox,
                    PoBoxCode = patient.PoBoxCode,
                    Occupation = patient.Occupation,
                    Language = patient.Language,
                    Gender = patient.Gender,
                    Race = patient.Race,
                    EmployerName = patient.EmployerName,
                    WorkAddress = patient.WorkAddress,
                    WorkAddressCity = patient.WorkAddressCity,
                    WorkAddressProvince = patient.WorkAddressProvince,
                    WorkAddressCode = patient.WorkAddressPostalCode,
                    NextOfKin = patient.NextOfKin,
                    NextOfKinContactNo = patient.NextOfKinContactNo,
                    RelationshipOfKin = patient.NextOfKinRelationship,
                    NextOfKinAltContactNo = patient.NextOfKinAltContactNo,
                    OtherContact = patient.OtherContact,
                    OtherContactNo = patient.OtherContactNo,
                    OtherContactRelationship = patient.OtherContactRelationship,
                    OtherContactAltContactNo = patient.OtherContactAltContactNo,
                    RefferingDoctor = patient.RefferingDoctor,
                    RefferingHospital = patient.RefferingHospital,
                    MedicalAidName = patient.MedicalAidName,
                    MedicalAidOption = patient.MedicalAidOption,
                    MedicalAidNo = patient.MedicalAidNo,
                    AuthNo = patient.AuthNo,
                    DependentCode = patient.DependentCode,
                    WoundLocation = patient.WoundLocation,
                    Stage = patient.WoundStage,
                    OT = patient.Ot,
                    Speech = patient.SpeechLanguage,
                    Psych = patient.Psychologist,
                    Dietician = patient.Dietician,
                    SocialWorker = patient.SocialWorker,
                    Physio = patient.Physio,
                    MainMedicalAidMemberFirstName = patient.MainMemberFirstName,
                    MainMedicalAidMemberLastName = patient.MainMemberLastName,
                    MainMedicalAidMemberIdNumber = patient.MedicalAidIdNumber,
                    MainMedicalAidMemberRelationship = patient.MainMemberRelationship,
                    MainMedicalAidMemberTelNo = patient.MainMemberTelNo,
                    MainMedicalAidMemberCellNo = patient.MainMemberCellNo,
                    MainMedicalAidMemberStreetAddress = patient.MainMemberStreetAddress,
                    MainMedicalAidMemberCity = patient.MainMemberCity,
                    MainMedicalAidMemberSuburb = patient.MainMemberSuburb,
                    MainMedicalAidMemberProvince = patient.MainMemberProvince,
                    MainMedicalAidMemberPostalAddress = patient.MainMemberPostalAddress,
                    MainMedicalAidMemberPostalAddressCode = patient.MainMemberPostalAddressCode,
                    MainMedicalAidMemberOccupation = patient.MainMemberOccupation,
                    MainMedicalAidMemberEmployer = patient.MainMemberEmployer,
                    MainMedicalAidMemberBusinessStreetAddress = patient.MainMemberBusinessStreetAddress,
                    MainMedicalAidMemberBusinessCity = patient.MainMemberBusinessCity,
                    MainMedicalAidMemberBusinessProvince = patient.MainMemberBusinessProvince,
                    MainMedicalAidMemberBusinessPostalCode = patient.MainMemberBusinessPostalCode
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
