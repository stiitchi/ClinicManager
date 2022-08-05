using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Patient.Queries
{
    public class GetAllAdmittedPatientsQuery : IRequest<Result<List<PatientDTO>>>
    {
    }

    public class GetAllAdmittedPatientsQueryHandler : IRequestHandler<GetAllAdmittedPatientsQuery, Result<List<PatientDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAdmittedPatientsQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<PatientDTO>>> Handle(GetAllAdmittedPatientsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PatientEntity, PatientDTO>> expression = e => new PatientDTO
                {
                    Id                                        = e.Id,
                    WardNo                                    = e.WardNO,
                    BedNo                                     = e.BedNO,
                    CaseInformationNumber                     = e.CaseInfomationNo,
                    AccountNo                                 = e.AccountNO,
                    AdmissionDate                             = e.AdmissionDate,
                    DateOfBirth                               = e.DateOfBirth,
                    DischargeDate                             = e.DischargeDate,
                    ReportDate                                = e.ReportDate,
                    Title                                     = e.Title,
                    Initials                                  = e.Initials,
                    FirstName                                 = e.FirstName,
                    LastName                                  = e.LastName,
                    IDNo                                      = e.IDNo,
                    PatientTelNo                              = e.PatientTelNo,
                    PatientCellNo                             = e.PatientCellNo,
                    PatientWorkTelNo                          = e.PatientWorkTelNo,
                    Email                                     = e.Email,
                    StreetAddress                             = e.StreetAddress,
                    City                                      = e.City,
                    Province                                  = e.Province,
                    PostalCode                                = e.PostalCode,
                    PoBox                                     = e.PoBox,
                    PoBoxCode                                 = e.PoBoxCode,
                    Suburb                                    = e.Suburb,
                    Occupation                                = e.Occupation,
                    Language                                  = e.Language,
                    Gender                                    = e.Gender,
                    Race                                      = e.Race,
                    EmployerName                              = e.EmployerName,
                    WorkAddress                               = e.WorkAddress,
                    WorkAddressCity                           = e.WorkAddressCity,
                    WorkAddressProvince                       = e.WorkAddressProvince,
                    WorkAddressCode                           = e.WorkAddressPostalCode,
                    NextOfKin                                 = e.NextOfKin,
                    NextOfKinContactNo                        = e.NextOfKinContactNo,
                    RelationshipOfKin                         = e.NextOfKinRelationship,
                    NextOfKinAltContactNo                     = e.NextOfKinAltContactNo,
                    OtherContact                              = e.OtherContact,
                    OtherContactNo                            = e.OtherContactNo,
                    OtherContactRelationship                  = e.OtherContactRelationship,
                    OtherContactAltContactNo                  = e.OtherContactAltContactNo,
                    RefferingDoctor                           = e.RefferingDoctor,
                    RefferingHospital                         = e.RefferingHospital,
                    MedicalAidName                            = e.MedicalAidName,
                    MedicalAidOption                          = e.MedicalAidOption,
                    MedicalAidNo                              = e.MedicalAidNo,
                    AuthNo                                    = e.AuthNo,
                    DependentCode                             = e.DependentCode,
                    WoundLocation                             = e.WoundLocation,
                    Stage                                     = e.WoundStage,
                    OT                                        = e.Ot,
                    Speech                                    = e.SpeechLanguage,
                    Psych                                     = e.Psychologist,
                    Dietician                                 = e.Dietician,
                    SocialWorker                              = e.SocialWorker,
                    Physio                                    = e.Physio,
                    MainMedicalAidMemberFirstName             = e.MainMemberFirstName,
                    MainMedicalAidMemberLastName              = e.MainMemberLastName,
                    MainMedicalAidMemberIdNumber              = e.MedicalAidIdNumber,
                    MainMedicalAidMemberRelationship          = e.MainMemberRelationship,
                    MainMedicalAidMemberTelNo                 = e.MainMemberTelNo,
                    MainMedicalAidMemberCellNo                = e.MainMemberCellNo,
                    MainMedicalAidMemberStreetAddress         = e.MainMemberStreetAddress,
                    MainMedicalAidMemberCity                  = e.MainMemberCity,
                    MainMedicalAidMemberSuburb                = e.MainMemberSuburb,
                    MainMedicalAidMemberProvince              = e.MainMemberProvince,
                    MainMedicalAidMemberPostalAddress         = e.MainMemberPostalAddress,
                    MainMedicalAidMemberPostalAddressCode     = e.MainMemberPostalAddressCode,
                    MainMedicalAidMemberOccupation            = e.MainMemberOccupation,
                    MainMedicalAidMemberEmployer              = e.MainMemberEmployer,
                    MainMedicalAidMemberBusinessStreetAddress = e.MainMemberBusinessStreetAddress,
                    MainMedicalAidMemberBusinessCity          = e.MainMemberBusinessCity,
                    MainMedicalAidMemberBusinessProvince      = e.MainMemberBusinessProvince,
                    MainMedicalAidMemberBusinessPostalCode    = e.MainMemberBusinessPostalCode,
                    IsAdmitted                                = e.IsAdmitted
                };

                var patients = await _context.Patients
                    .AsNoTracking()
                    .Where(x => x.IsAdmitted == true)
                    .Select(expression)
                    .ToListAsync(cancellationToken);
                return await Result<List<PatientDTO>>.SuccessAsync(patients);

            }
            catch (Exception ex)
            {
                return await Result<List<PatientDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
