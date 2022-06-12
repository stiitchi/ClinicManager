using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.AdmissionAggregate;
using ClinicManager.Domain.Entities.UserAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static ClinicManager.Shared.Constants.Constants;

namespace ClinicManager.Application.Modules.Admissions.Commands
{
    public class AddAdmissionCommand : IRequest<Result<int>>
    {
        public int AdmissionId { get; set; }
        public int PatientId { get; set; }
        public int CaseInformationNumber { get; set; }
        public int AccountNo { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime AdmissionTime { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Initials { get; set; }
        public int IDNo { get; set; }
        public int HomeTelNo { get; set; }
        public int WorkTelNo { get; set; }
        public int CellNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string HomeAddress { get; set; }
        public string Email { get; set; }
        public string POBox { get; set; }
        public int POBoxCode { get; set; }
        public string Occupation { get; set; }
        public string Language { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public int HomePostalCode { get; set; }
        public string EmployerName { get; set; }
        public string WorkAddress { get; set; }
        public string WorkAddressPostalCode { get; set; }
        public string NextOfKin { get; set; }
        public int ContactNoKin { get; set; }
        public string RelationshipOfKin { get; set; }
        public int AltContactNoKin { get; set; }
        public string OtherContact { get; set; }
        public int AltKinContactNo { get; set; }
        public string OtherContactRelationship { get; set; }
        public string MedicalAidNo { get; set; }
        public string MedicalAidName { get; set; }
        public string MedicalAidOption { get; set; }
        public string AuthNo { get; set; }
        public string DependentCode { get; set; }
        public string MedicalAidMemberFullName { get; set; }
        public int MedicalAidMemberIdNo { get; set; }
        public string MedicalAidMemberRelationship { get; set; }
        public string MedicalAidMemberPostalAddress { get; set; }
        public string MedicalAidMemberPostalAddressCode { get; set; }
        public string MedicalAidMemberHomeAddress { get; set; }
        public string MedicalAidMemberHomePostalCode { get; set; }
        public string MedicalAidMemberOccupation { get; set; }
        public string MedicalAidMemberEmployerName { get; set; }
        public string MedicalAidMemberBusinessAddress { get; set; }
        public string MedicalAidMemberBusinessPostalCode { get; set; }
        public int OtherContactNo { get; set; }
        public int OtherContactNoAlt { get; set; }
        public string MemberCode { get; set; }
        public int MedicalAidMemberTelNo { get; set; }
        public int MedicalAidMemberCellNo { get; set; }
    }

    public class AddAdmissionCommandHandler : IRequestHandler<AddAdmissionCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddAdmissionCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddAdmissionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var admissions = await _context.Admissions.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.AdmissionId, cancellationToken);
                if (admissions != null)
                    throw new Exception("Admission already exists");

                var admission = new AdmissionEntity(
                   request.CaseInformationNumber,
                   request.AccountNo,
                   request.AdmissionDate,
                   request.AdmissionTime,
                   request.Title,
                   request.Initials,
                   request.LastName,
                   request.FullName,
                   request.IDNo,
                   request.DateOfBirth,
                   request.HomeTelNo,
                   request.CellNo,
                   request.WorkTelNo,
                   request.Email,
                   request.HomeAddress,
                   request.HomePostalCode,
                   request.POBox,
                   request.POBoxCode,
                   request.Occupation,
                   request.Language,
                   request.Gender,
                   request.Race,
                   request.EmployerName,
                   request.WorkAddress,
                   request.WorkAddressPostalCode,
                   request.NextOfKin,
                   request.ContactNoKin,
                   request.RelationshipOfKin,
                   request.AltKinContactNo,
                   request.OtherContact,
                   request.OtherContactNo,
                   request.OtherContactRelationship,
                   request.OtherContactNoAlt,
                   request.MedicalAidName,
                   request.MedicalAidOption,
                   request.MedicalAidNo,
                   request.AuthNo,
                   request.DependentCode,
                   request.MedicalAidMemberFullName,
                   request.MedicalAidMemberIdNo,
                   request.MedicalAidMemberRelationship,
                   request.MedicalAidMemberTelNo,
                   request.MedicalAidMemberCellNo,
                   request.MedicalAidMemberPostalAddress,
                   request.MedicalAidMemberPostalAddressCode,
                   request.MedicalAidMemberHomeAddress,
                   request.MedicalAidMemberHomePostalCode,
                   request.MedicalAidMemberOccupation,
                   request.MedicalAidMemberEmployerName,
                   request.MedicalAidMemberBusinessAddress,
                   request.MedicalAidMemberBusinessPostalCode
                    );

                var user = await _context.Users.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.AdmissionId, cancellationToken);
                if (user != null)
                    throw new Exception("Admission already exists");

                var newUser = new UserEntity(
                 request.FullName,
                 request.LastName,
                 request.Email,
                 request.CellNo.ToString()
                  );

                newUser.SetRole(RoleConstants.ADMITTED);


                await _context.Users.AddAsync(newUser, cancellationToken);

                await _context.Admissions.AddAsync(admission, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(admission.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
