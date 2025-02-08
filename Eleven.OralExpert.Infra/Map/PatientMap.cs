using Eleven.OralExpert.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eleven.OralExpert.Infra.Map;

public class PatientMap : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
       
        builder.Property(p => p.MedicalRecord)
            .IsRequired()
            .HasMaxLength(500); 
        
        builder.OwnsOne(u => u.Address, address =>
        {
            address.Property(a => a.Street).HasColumnName("Street").HasMaxLength(150);
            address.Property(a => a.Neighborhood).HasColumnName("Neighborhood").HasMaxLength(100);
            address.Property(a => a.City).HasColumnName("City").HasMaxLength(100);
            address.Property(a => a.ZipCode).HasColumnName("ZipCode").HasMaxLength(20);
            address.Property(a => a.State).HasColumnName("State").HasMaxLength(50);
        });
    }
}