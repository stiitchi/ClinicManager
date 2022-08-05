using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.AdmissionAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Admissions.Queries
{
  public class GetAllAdmissionsQuery : IRequest<Result<List<AdmissionDTO>>>
    {
    }

    public class GetAllAdmissionsQueryHandler : IRequestHandler<GetAllAdmissionsQuery, Result<List<AdmissionDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAdmissionsQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<AdmissionDTO>>> Handle(GetAllAdmissionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<AdmissionEntity, AdmissionDTO>> expression = e => new AdmissionDTO
                {
                    AdmissionId                        = e.Id, 
                    CaseInformationNumber              = e.CaseInformationNo,
                    AccountNo                          = e.AccountNo,
                    AdmissionDate                      = e.AdmissionDate,
                    AdmissionTime                      = e.AdmissionTime,
                    Title                              = e.Title,
                    Initials                           = e.Initials,
                    LastName                           = e.LastName,
                    PatientFullName                    = e.FullName,
                    IDNo                               = e.IDNo,
                    DateOfBirth                        = e.DateOfBirth,
                    HomeTelNo                          = e.HomeTelNo,
                    CellNo                             = e.CellNo,
                    WorkTelNo                          = e.WorkTelNo,
                    Email                              = e.Email,
                    HomeAddress                        = e.HomeAddress,
                    HomePostalCode                     = e.PostalCode,
                    POBox                              = e.PoBox,
                    POBoxCode                          = e.PoBoxCode,
                    Occupation                         = e.Occupation,
                    Language                           = e.Language,
                    Gender                             = e.Gender,
                    Race                               = e.Race,
                    EmployerName                       = e.EmployerName,
                    WorkAddress                        = e.WorkAddress,
                    WorkAddressPostalCode              = e.WorkAddressPostalCode,
                    NextOfKin                          = e.NextOfKin,
                    ContactNoKin                       = e.ContactNoKin,
                    RelationshipOfKin                  = e.RelationshipOfKin,
                    AltContactNoKin                    = e.AltContactNoKin,
                    OtherContact                       = e.OtherContact,
                    OtherContactNo                     = e.OtherContactNo,
                    OtherContactRelationship           = e.OtherContactRelationship,
                    OtherContactNoAlt                  = e.OtherContactNoAlt,
                    MedicalAidName                     = e.MedicalAidName,
                    MedicalAidOption                   = e.MedicalAidOption,
                    MedicalAidNo                       = e.MedicalAidNo,
                    AuthNo                             = e.AuthNo,
                    DependentCode                      = e.DependentCode,
                    MedicalAidMemberFullName           = e.MedicalAidMemberFullName,
                    MedicalAidMemberIdNo               = e.MedicalAidMemberIdNo,
                    MedicalAidMemberRelationship       = e.MedicalAidMemberRelationship,
                    MedicalAidMemberTelNo              = e.MedicalAidMemberTelNo,
                    MedicalAidMemberCellNo             = e.MedicalAidMemberCellNo,
                    MedicalAidMemberPostalAddress      = e.MedicalAidMemberPostalAddress,
                    MedicalAidMemberPostalAddressCode  = e.MedicalAidMemberPostalAddressCode,
                    MedicalAidMemberHomeAddress        = e.MedicalAidMemberHomeAddress,
                    MedicalAidMemberHomePostalCode     = e.MedicalAidMemberHomePostalCode,
                    MedicalAidMemberOccupation         = e.MedicalAidMemberOccupation,
                    MedicalAidMemberEmployerName       = e.MedicalAidMemberEmployer,
                    MedicalAidMemberBusinessAddress    = e.MedicalAidMemberBusinessAddress,
                    MedicalAidMemberBusinessPostalCode = e.MedicalAidMemberBusinessPostalCode
                };

                var admissions = await _context.Admissions
                    .AsNoTracking()
                    .Select(expression)
                    .ToListAsync(cancellationToken);
                return await Result<List<AdmissionDTO>>.SuccessAsync(admissions);
            }
            catch (Exception ex)
            {
                return await Result<List<AdmissionDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
