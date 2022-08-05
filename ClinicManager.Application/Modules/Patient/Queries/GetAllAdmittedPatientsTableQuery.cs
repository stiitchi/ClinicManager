using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using ClinicManager.Application.Extensions;

namespace ClinicManager.Application.Modules.Patient.Queries
{
    public class GetAllAdmittedPatientsTableQuery : IRequest<PaginatedResult<PatientDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; }

        public GetAllAdmittedPatientsTableQuery(int pageNumber, int pageSize, string searchString, string orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }

    public class GetAllAdmittedPatientsTableQueryHandler : IRequestHandler<GetAllAdmittedPatientsTableQuery, PaginatedResult<PatientDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAdmittedPatientsTableQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedResult<PatientDTO>> Handle(GetAllAdmittedPatientsTableQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PatientEntity, PatientDTO>> expression = e => new PatientDTO
                {
                    Id                                        = e.Id,
                    FirstName                                 = e.FirstName,
                    LastName                                  = e.LastName,
                    AccountNo                                 = e.AccountNO,
                    AdmissionDate                             = e.AdmissionDate,
                    AuthNo                                    = e.AuthNo,
                    BedNo                                     = e.BedNO,
                    RoomNo                                    = e.RoomNo,
                    CaseInformationNumber                     = e.CaseInfomationNo,
                    City                                      = e.City,
                    DateOfBirth                               = e.DateOfBirth,
                    DependentCode                             = e.DependentCode,
                    Dietician                                 = e.Dietician,
                    DischargeDate                             = e.DischargeDate,
                    Email                                     = e.Email,
                    EmployerName                              = e.EmployerName,
                    Gender                                    = e.Gender,
                    IDNo                                      = e.IDNo,
                    Initials                                  = e.Initials,
                    Language                                  = e.Language,
                    MainMedicalAidMemberBusinessCity          = e.MainMemberBusinessCity,
                    MainMedicalAidMemberBusinessPostalCode    = e.MainMemberBusinessPostalCode,
                    MainMedicalAidMemberBusinessProvince      = e.MainMemberBusinessProvince,
                    MainMedicalAidMemberBusinessStreetAddress = e.MainMemberBusinessStreetAddress,
                    MainMedicalAidMemberCellNo                = e.MainMemberCellNo,
                    MainMedicalAidMemberCity                  = e.MainMemberCity,
                    MainMedicalAidMemberEmployer              = e.MainMemberEmployer,
                    MainMedicalAidMemberFirstName             = e.MainMemberFirstName,
                    MainMedicalAidMemberIdNumber              = e.MedicalAidIdNumber,
                    MainMedicalAidMemberLastName              = e.MainMemberLastName,
                    MainMedicalAidMemberOccupation            = e.MainMemberOccupation,
                    MainMedicalAidMemberPostalAddress         = e.MainMemberPostalAddress,
                    MainMedicalAidMemberPostalAddressCode     = e.MainMemberPostalAddressCode,
                    MainMedicalAidMemberProvince              = e.MainMemberProvince,
                    MainMedicalAidMemberRelationship          = e.MainMemberRelationship,
                    MainMedicalAidMemberStreetAddress         = e.MainMemberStreetAddress,
                    MainMedicalAidMemberSuburb                = e.MainMemberSuburb,
                    MainMedicalAidMemberTelNo                 = e.MainMemberTelNo,
                    MedicalAidName                            = e.MedicalAidName,
                    MedicalAidNo                              = e.MedicalAidNo,
                    MedicalAidOption                          = e.MedicalAidOption,
                    NextOfKin                                 = e.NextOfKin,
                    NextOfKinAltContactNo                     = e.NextOfKinAltContactNo,
                    NextOfKinContactNo                        = e.NextOfKinContactNo,
                    Occupation                                = e.Occupation,
                    OT                                        = e.Ot,
                    OtherContact                              = e.OtherContact,
                    OtherContactAltContactNo                  = e.OtherContactAltContactNo,
                    OtherContactNo                            = e.OtherContactNo,
                    OtherContactRelationship                  = e.OtherContactRelationship,
                    PatientCellNo                             = e.PatientCellNo,
                    PatientTelNo                              = e.PatientTelNo,
                    PatientWorkTelNo                          = e.PatientWorkTelNo,
                    Physio                                    = e.Physio,
                    PoBox                                     = e.PoBox,
                    PoBoxCode                                 = e.PoBoxCode,
                    PostalCode                                = e.PostalCode,
                    Province                                  = e.Province,
                    Psych                                     = e.Psychologist,
                    Race                                      = e.Race,
                    RefferingDoctor                           = e.RefferingDoctor,
                    RefferingHospital                         = e.RefferingHospital,
                    RelationshipOfKin                         = e.NextOfKinRelationship,
                    ReportDate                                = e.ReportDate,
                    SocialWorker                              = e.SocialWorker,
                    Speech                                    = e.SpeechLanguage,
                    Stage                                     = e.WoundStage,
                    StreetAddress                             = e.StreetAddress,
                    Suburb                                    = e.Suburb,
                    Title                                     = e.Title,
                    WardNo                                    = e.WardNO,
                    WorkAddress                               = e.WorkAddress,
                    WorkAddressCity                           = e.WorkAddressCity,
                    WorkAddressCode                           = e.WorkAddressPostalCode,
                    WorkAddressProvince                       = e.WorkAddressProvince,
                    WoundLocation                             = e.WoundLocation,
                    IsAdmitted                                = e.IsAdmitted
                };

                IQueryable<PatientEntity> query = _context.Patients;

                if (!string.IsNullOrEmpty(request.SearchString))
                    query = query.Where(o => o.FirstName.ToString().Contains(request.SearchString) ||
                                             o.LastName.ToString().Contains(request.SearchString) ||
                                             o.RefferingDoctor.ToString().Contains(request.SearchString) ||
                                             o.RefferingHospital.ToString().Contains(request.SearchString) ||
                                             o.WardNO.ToString().Contains(request.SearchString)
                                             );

                if (request.OrderBy?.Any() != true)
                {
                    var result = await query
                   .AsNoTracking()
                   .IgnoreQueryFilters()
                   .Where(x => x.IsAdmitted == true)
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return result;
                }
                else
                {
                    var ordering = string.Join(",", request.OrderBy);
                    var result = await query
                    .AsNoTracking()
                    .IgnoreQueryFilters()
                    .Where(x => x.IsAdmitted == true)
                    .OrderBy(ordering)
                    .Select(expression)
                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return await PaginatedResult<PatientDTO>.FailureAsync(new List<string> { ex.Message });
            }
        }
    }
}
