using ClinicManager.Domain.Entities.AdmissionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Admission
{
    public class AdmissionEntityConfiguration : IEntityTypeConfiguration<AdmissionEntity>
    {
        public void Configure(EntityTypeBuilder<AdmissionEntity> conf)
        {
            conf.ToTable("Admissions", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.IsActive).IsRequired();
            conf.Property(c => c.CaseInformationNo).HasMaxLength(200).IsRequired();
            conf.Property(c => c.AccountNo).HasMaxLength(200).IsRequired(); 
            conf.Property(c => c.AdmissionDate).IsRequired(); 
            conf.Property(c => c.AdmissionTime).IsRequired();
            conf.Property(c => c.Title).IsRequired();
            conf.Property(c => c.Initials).IsRequired();
            conf.Property(c => c.LastName).HasMaxLength(200).IsRequired();
            conf.Property(c => c.FullName).HasMaxLength(200).IsRequired(); 
            conf.Property(c => c.IDNo).IsRequired();
            conf.Property(c => c.DateOfBirth).IsRequired();
            conf.Property(c => c.HomeTelNo).IsRequired();
            conf.Property(c => c.CellNo).IsRequired();
            conf.Property(c => c.WorkTelNo).IsRequired();
            conf.Property(c => c.HomeAddress).IsRequired();
            conf.Property(c => c.PostalCode).IsRequired();
            conf.Property(c => c.PoBox).IsRequired(false);
            conf.Property(c => c.PoBoxCode);
            conf.Property(c => c.Occupation).IsRequired();
            conf.Property(c => c.Language).IsRequired();
            conf.Property(c => c.Gender).IsRequired();
            conf.Property(c => c.Race).IsRequired();
            conf.Property(c => c.EmployerName).IsRequired();
            conf.Property(c => c.WorkAddress).IsRequired();
            conf.Property(c => c.WorkAddressPostalCode).IsRequired();
            conf.Property(c => c.NextOfKin).IsRequired();
            conf.Property(c => c.ContactNoKin).IsRequired();
            conf.Property(c => c.RelationshipOfKin).IsRequired();
            conf.Property(c => c.AltContactNoKin).IsRequired();
            conf.Property(c => c.OtherContact).IsRequired(false);
            conf.Property(c => c.OtherContactNo).IsRequired();
            conf.Property(c => c.OtherContactRelationship).IsRequired(false);
            conf.Property(c => c.OtherContactNoAlt);
            conf.Property(c => c.MedicalAidName).IsRequired(false);
            conf.Property(c => c.MedicalAidOption).IsRequired(false);
            conf.Property(c => c.MedicalAidNo).IsRequired(false);
            conf.Property(c => c.AuthNo).IsRequired(false);
            conf.Property(c => c.DependentCode).IsRequired(false);
            conf.Property(c => c.MedicalAidMemberFullName).IsRequired();
            conf.Property(c => c.MedicalAidMemberIdNo).IsRequired();
            conf.Property(c => c.MedicalAidMemberRelationship).IsRequired();
            conf.Property(c => c.MedicalAidMemberTelNo).IsRequired();
            conf.Property(c => c.MedicalAidMemberCellNo).IsRequired();
            conf.Property(c => c.MedicalAidMemberPostalAddress).IsRequired();
            conf.Property(c => c.MedicalAidMemberPostalAddressCode).IsRequired();
            conf.Property(c => c.MedicalAidMemberHomeAddress).IsRequired();
            conf.Property(c => c.MedicalAidMemberHomePostalCode).IsRequired();
            conf.Property(c => c.MedicalAidMemberOccupation).IsRequired();
            conf.Property(c => c.MedicalAidMemberEmployer).IsRequired(false);
            conf.Property(c => c.MedicalAidMemberBusinessAddress).IsRequired(false);
            conf.Property(c => c.MedicalAidMemberBusinessPostalCode).IsRequired(false);

            conf.HasIndex(c => c.Id);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
