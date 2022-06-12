using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.Patient.Queries
{
  public class GetAllPatientsQuery : IRequest<Result<List<PatientDTO>>>
    {
    }

    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, Result<List<PatientDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPatientsQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<PatientDTO>>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PatientEntity, PatientDTO>> expression = e => new PatientDTO
                {
                    Id = e.Id,
                    AccountNo = e.AccountNo,
                    Address = e.Address,
                    AdmissionDate = e.AdmissionDate,
                    AdmissionTime = e.AdmissionTime,
                    AltContact = e.AltContact,
                    AltContactNo = e.AltContactNo,
                    AltContactRelationship = e.AltContactRelationship,
                    AuthNo = e.AuthNo,
                    CaseInformationNumber = e.CaseInformationNo,
                    CellNo = e.CellNo,
                    ContactNo = e.ContactNo,
                    DateOfBirth = e.DateOfBirth,
                    DependentCode = e.DependentCode,
                    EmployerName = e.EmployerName,
                    FullName = e.FullName,
                    Gender = e.Gender,
                    HomeTelNo = e.HomeTelNo,
                    IDNo = e.IDNo,
                    Initials = e.Initials,
                    Language = e.Language,
                    LastName = e.LastName,
                    MedicalAidMemberBusinessAddress = e.MedicalAidMemberBusinessAddress,
                    MedicalAidMemberBusinessPostalCode = e.MedicalAidMemberBusinessPostalCode,
                    MedicalAidMemberCellNo = e.MedicalAidMemberCellNo,
                    MedicalAidMemberCode = e.MedicalAidMemberCode,
                    MedicalAidMemberEmployer = e.MedicalAidMemberEmployer,
                    MedicalAidMemberIdNo = e.MedicalAidMemberIdNo,
                    MedicalAidMemberName = e.MedicalAidMemberName,
                    MedicalAidMemberOccupation = e.MedicalAidMemberOccupation,
                    MedicalAidMemberPostalAddress = e.MedicalAidMemberPostalAddress,
                    MedicalAidMemberSurname = e.MedicalAidMemberSurname,
                    MedicalAidMemberTelNo = e.MedicalAidMemberTelNo,
                    MedicalAidName = e.MedicalAidName,
                    MedicalAidNo = e.MedicalAidNo,
                    MedicalAidOption = e.MedicalAidOption,
                    NextOfKin = e.NextOfKin,
                    Occupation = e.Occupation,
                    POBox = e.PoBox,
                    POBoxCode = e.PoBoxCode,
                    Race = e.Race,
                    RelationshipOfKin = e.RelationshipOfKin,
                    Title = e.Title,
                    WorkAddress = e.WorkAddress,
                    WorkAddressPostalCode = e.WorkAddressPostalCode,
                    WorkTelNo = e.WorkTelNo
                };

                var patients = await _context.Patients
                    .AsNoTracking()
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
