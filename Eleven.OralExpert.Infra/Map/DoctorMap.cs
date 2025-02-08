using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Eleven.OralExpert.Domain.Entities;

namespace Eleven.OralExpert.Infra.Map;
public class DoctorMap : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
       
        
        builder.Property(d => d.CRO)
            .HasMaxLength(20)
            .IsRequired(false);

        builder.Property(d => d.Specialty)
            .IsRequired()
            .HasMaxLength(100);
        
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