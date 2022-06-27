using ClinicManager.Shared.DTO_s;
using FluentValidation;

namespace ClinicManager.Data.Modals.Patient.Validation
{
    public class AddEditPatientFluentValidation : AbstractValidator<PatientDTO>
    {
        public AddEditPatientFluentValidation()
        {
            RuleFor(x => x.AdmissionDate).NotEmpty().WithMessage("Please specify an Admission Date");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Please provide a Date Of Birth");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please specify a First Name");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please specify a Last Name");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Please specify a Title");
            RuleFor(x => x.IDNo).NotEmpty().WithMessage("Please specify a valid  ID Number").GreaterThan(12).LessThan(14);
            RuleFor(x => x.EmergencyContactIdNo).NotEmpty().WithMessage("Please specify a valid Emergency ID Number").GreaterThan(12).LessThan(14);
            RuleFor(x => x.WardNo.ToString()).NotEmpty().Must(IsValidNumber).WithMessage("Please provide a valid Ward");
            RuleFor(x => x.BedNo.ToString()).NotEmpty().Must(IsValidNumber).WithMessage("Please provide a valid Bed Number");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Please provide a Location");
            RuleFor(x => x.Language).NotEmpty().WithMessage("Please specify a Language");
            RuleFor(x => x.Stage).NotEmpty().WithMessage("Please specify a Stage");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Please specify a Gender");
            RuleFor(x => x.Relationship).NotEmpty().WithMessage("Please specify a Relationship");
            RuleFor(x => x.RefferingDoctor).NotEmpty().WithMessage("Please specify a Reffering Doctor");
            RuleFor(x => x.MedicalAidName).NotEmpty().WithMessage("Please specify a Medical Aid Name");
            RuleFor(x => x.MedicalAidOption).NotEmpty().WithMessage("Please specify a Medical Aid Option");
            RuleFor(x => x.DependentCode).NotEmpty().WithMessage("Please specify a Dependent Code");
            RuleFor(x => x.Race).NotEmpty().WithMessage("Please specify a Race");
            RuleFor(x => x.EmergencyContactFirstName).NotEmpty().WithMessage("Please specify a Emergency Contact First Name");
            RuleFor(x => x.EmergencyContactLastName).NotEmpty().WithMessage("Please specify a Emergency Contact Last Name");
            RuleFor(x => x.MedicalAidNo.ToString()).NotEmpty().Must(IsValidNumber).MinimumLength(9).MaximumLength(9).WithMessage("Please provide a valid Medical Aid Number");
            RuleFor(x => x.EmergencyContactNo.ToString()).NotEmpty().Must(IsValidNumber).MinimumLength(10).MaximumLength(10).WithMessage("Please provide a valid Emergency Contact Number");
        }

        public bool IsValidNumber(string number)
        {
            if (number == null)
            {
                return false;
            }
            else
            {
                return number.All(Char.IsNumber);
            }
        }
    }
}
