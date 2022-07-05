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
        public int AccountNo { get; set; }
        public int CaseInformationNumber { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public DateTime? ReportDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Initials { get; set; }
        public long IDNo { get; set; }
        public string WardNo { get; set; }
        public int BedNo { get; set; }
        public string PatientTelNo { get; set; }
        public string PatientCellNo { get; set; }
        public string PatientWorkTelNo { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public string PoBox { get; set; }
        public string PoBoxCode { get; set; }
        public string Occupation { get; set; }
        public string Race { get; set; }
        public string EmployerName { get; set; }
        public string Province { get; set; }
        public string WorkAddress { get; set; }
        public string WorkAddressCity { get; set; }
        public string WorkAddressProvince { get; set; }
        public string WorkAddressCode { get; set; }
        public string Language { get; set; }
        public string Gender { get; set; }

        public string NextOfKin { get; set; }
        public string NextOfKinContactNo { get; set; }
        public string RelationshipOfKin { get; set; }
        public string NextOfKinAltContactNo { get; set; }

        public string OtherContact { get; set; }
        public string OtherContactNo { get; set; }
        public string OtherContactRelationship { get; set; }
        public string OtherContactAltContactNo { get; set; }

        public string WoundLocation { get; set; }
        public string Stage { get; set; }
        public string RefferingDoctor { get; set; }
        public string RefferingHospital { get; set; }

        public string MedicalAidNo { get; set; }
        public string MedicalAidName { get; set; }
        public string MedicalAidOption { get; set; }
        public string DependentCode { get; set; }
        public string AuthNo { get; set; }

        public string MainMedicalAidMemberFirstName { get; set; }
        public string MainMedicalAidMemberLastName { get; set; }
        public string MainMedicalAidMemberTelNo { get; set; }
        public string MainMedicalAidMemberCellNo { get; set; }
        public string MainMedicalAidMemberPostalAddress { get; set; }
        public string MainMedicalAidMemberPostalAddressCode { get; set; }
        public string MainMedicalAidMemberSuburb { get; set; }
        public string MainMedicalAidMemberCity { get; set; }
        public string MainMedicalAidMemberProvince { get; set; }
        public string MainMedicalAidMemberStreetAddress { get; set; }
        public string MainMedicalAidMemberOccupation { get; set; }
        public string MainMedicalAidMemberEmployer { get; set; }
        public string MainMedicalAidMemberBusinessStreetAddress { get; set; }
        public string MainMedicalAidMemberBusinessCity { get; set; }
        public string MainMedicalAidMemberBusinessProvince { get; set; }
        public string MainMedicalAidMemberRelationship { get; set; }
        public string MainMedicalAidBusinessPostalCode{ get; set; }
        public long MainMedicalAidMemberIdNumber { get; set; }

        public bool OT { get; set; }
        public bool Speech { get; set; }
        public bool Psych { get; set; }
        public bool Dietician { get; set; }
        public bool SocialWorker { get; set; }
        public bool Physio { get; set; }
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
                request.WardNo,
                request.BedNo,
                request.CaseInformationNumber,
                request.AccountNo,
                request.AdmissionDate,
                request.DateOfBirth,
                request.DischargeDate,
                request.ReportDate,
                request.Title,
                request.Initials,
                request.FirstName,
                request.LastName,
                request.IDNo,
                request.PatientTelNo,
                request.PatientCellNo,
                request.PatientWorkTelNo,
                request.Email,
                request.StreetAddress,
                request.Suburb,
                request.City,
                request.Province,
                request.PostalCode,
                request.PoBox,
                request.PoBoxCode,
                request.Occupation,
                request.Language,
                request.Gender,
                request.Race,
                request.EmployerName,
                request.WorkAddress,
                request.WorkAddressCity,
                request.WorkAddressProvince,
                request.WorkAddressCode,
                request.NextOfKin,
                request.NextOfKinContactNo,
                request.RelationshipOfKin,
                request.NextOfKinAltContactNo,
                request.OtherContact,
                request.OtherContactNo,
                request.OtherContactRelationship,
                request.OtherContactAltContactNo,
                request.RefferingDoctor,
                request.RefferingHospital,
                request.MedicalAidName,
                request.MedicalAidOption,
                request.MedicalAidNo,
                request.AuthNo,
                request.DependentCode,
                request.WoundLocation,
                request.Stage,
                request.OT,
                request.Speech,
                request.Psych,
                request.Dietician,
                request.SocialWorker,
                request.Physio,
                request.MainMedicalAidMemberFirstName,
                request.MainMedicalAidMemberLastName,
                request.MainMedicalAidMemberIdNumber,
                request.MainMedicalAidMemberRelationship,
                request.MainMedicalAidMemberTelNo,
                request.MainMedicalAidMemberCellNo,
                request.MainMedicalAidMemberStreetAddress,
                request.MainMedicalAidMemberCity,
                request.MainMedicalAidMemberSuburb,
                request.MainMedicalAidMemberProvince,
                request.MainMedicalAidMemberPostalAddress,
                request.MainMedicalAidMemberPostalAddressCode,
                request.MainMedicalAidMemberOccupation,
                request.MainMedicalAidMemberEmployer,
                request.MainMedicalAidMemberBusinessStreetAddress,
                request.MainMedicalAidMemberBusinessCity,
                request.MainMedicalAidMemberBusinessProvince,
                request.MainMedicalAidBusinessPostalCode
                );

                var patientName = $"{request.Title} {request.FirstName} {request.LastName}";

                var bed = await _context.Beds.IgnoreQueryFilters()
                                             .FirstOrDefaultAsync(c => c.BedNumber == request.BedNo, cancellationToken);
                if (bed == null)
                    throw new Exception("Bed doesn't exists");

                await _context.Patients.AddAsync(patient, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                var newPatient = await _context.Patients.IgnoreQueryFilters()
                                                .FirstOrDefaultAsync(c => c.Id == patient.Id, cancellationToken);
                if (newPatient == null)
                    throw new Exception("Patient doesn't exists");

                bed.AssignPatientToBed(newPatient);

                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(bed.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
