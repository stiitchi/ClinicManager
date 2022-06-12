using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Admissions.Commands
{
    public class EditAdmissionCommand : IRequest<Result<AdmissionDTO>>
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

    public class EditAdmissionCommandHandler : IRequestHandler<EditAdmissionCommand, Result<AdmissionDTO>>
    {
        private readonly IApplicationDbContext _context;

        public EditAdmissionCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<AdmissionDTO>> Handle(EditAdmissionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //var admission = await _context.Admissions.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.AdmissionId, cancellationToken);
                //if (admission == null)
                //    throw new Exception("Admission does not exist");

                //var patient = await _context.Patients.IgnoreQueryFilters()
                //                          .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                //if (patient != null)
                //    throw new Exception("Patient already exists");

                //admission.Set(
                //     request.CaseInformationNumber,
                //     request.AccountNo,
                //     request.AdmissionDate,
                //     request.AdmissionTime,
                //     request.FullName,
                //     request.LastName,
                //     request.Title,
                //     request.Initials,
                //     request.IDNo,
                //     request.HomeTelNo,
                //     request.WorkTelNo,
                //     request.CellNo,
                //     request.DateOfBirth,
                //     request.Address,
                //     request.POBox,
                //     request.POBoxCode,
                //     request.Occupation,
                //     request.Language,
                //     request.Gender,
                //     request.Race,
                //     request.EmployerName,
                //     request.WorkAddress,
                //     request.WorkAddressPostalCode,
                //     request.NextOfKin,
                //     request.ContactNo,
                //     request.RelationshipOfKin,
                //     request.AltContactNo,
                //     request.AltContact,
                //     request.AltContactRelationship,
                //     request.MedicalAidNo,
                //     request.MedicalAidName,
                //     request.MedicalAidOption,
                //     request.AuthNo,
                //     request.DependentCode,
                //     request.MedicalAidMemberName,
                //     request.MedicalAidMemberSurname,
                //     request.MedicalAidMemberIdNo,
                //     request.MedicalAidMemberTelNo,
                //     request.MedicalAidMemberCellNo,
                //     request.MedicalAidMemberPostalAddress,
                //     request.MedicalAidMemberCode,
                //     request.MedicalAidMemberOccupation,
                //     request.MedicalAidMemberEmployer,
                //     request.MedicalAidMemberBusinessAddress,
                //     request.MedicalAidMemberBusinessPostalCode,
                //     patient
                //      );

                await _context.SaveChangesAsync(cancellationToken);
                return await Result<AdmissionDTO>.SuccessAsync("Admission Updated");
            }
            catch (Exception ex)
            {
                return await Result<AdmissionDTO>.FailAsync(ex.Message);
            }
        }
    }
}
