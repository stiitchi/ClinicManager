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
        public string Address { get; set; }
        public string POBox { get; set; }
        public int POBoxCode { get; set; }
        public string Occupation { get; set; }
        public string Language { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string EmployerName { get; set; }
        public string WorkAddress { get; set; }
        public string WorkAddressPostalCode { get; set; }
        public string NextOfKin { get; set; }
        public string ContactNo { get; set; }
        public string RelationshipOfKin { get; set; }
        public string AltContact { get; set; }
        public string AltContactNo { get; set; }
        public string AltContactRelationship { get; set; }
        public string MedicalAidNo { get; set; }
        public string MedicalAidName { get; set; }
        public string MedicalAidOption { get; set; }
        public string AuthNo { get; set; }
        public string DependentCode { get; set; }
        public string MedicalAidMemberName { get; set; }
        public string MedicalAidMemberSurname { get; set; }
        public string MedicalAidMemberIdNo { get; set; }
        public string MedicalAidMemberTelNo { get; set; }
        public string MedicalAidMemberCellNo { get; set; }
        public string MedicalAidMemberPostalAddress { get; set; }
        public string MedicalAidMemberCode { get; set; }
        public string MedicalAidMemberOccupation { get; set; }
        public string MedicalAidMemberEmployer { get; set; }
        public string MedicalAidMemberBusinessAddress { get; set; }
        public string MedicalAidMemberBusinessPostalCode { get; set; }
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
                request.CaseInformationNumber,
                request.AccountNo,
                request.AdmissionDate,
                request.AdmissionTime,
                request.FullName,
                request.LastName,
                request.Title,
                request.Initials,
                request.IDNo,
                request.HomeTelNo,
                request.WorkTelNo,
                request.CellNo,
                request.DateOfBirth,
                request.Address,
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
                request.ContactNo,
                request.RelationshipOfKin,
                request.AltContactNo,
                request.AltContact,
                request.AltContactRelationship,
                request.MedicalAidNo,
                request.MedicalAidName,
                request.MedicalAidOption,
                request.AuthNo,
                request.DependentCode,
                request.MedicalAidMemberName,
                request.MedicalAidMemberSurname,
                request.MedicalAidMemberIdNo,
                request.MedicalAidMemberTelNo,
                request.MedicalAidMemberCellNo,
                request.MedicalAidMemberPostalAddress,
                request.MedicalAidMemberCode,
                request.MedicalAidMemberOccupation,
                request.MedicalAidMemberEmployer,
                request.MedicalAidMemberBusinessAddress,
                request.MedicalAidMemberBusinessPostalCode);
  

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
