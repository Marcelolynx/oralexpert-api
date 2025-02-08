using Eleven.OralExpert.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eleven.OralExpert.Infra.Map;

public class ClinicMap : IEntityTypeConfiguration<Clinic>
{
    public void Configure(EntityTypeBuilder<Clinic> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.BrandName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.CorporateName)
            .IsRequired()
            .HasMaxLength(150);

        // 🔥 Address como Owned Entity
        builder.OwnsOne(c => c.Address, address =>
        {
            address.Property(a => a.Street).HasColumnName("Street").HasMaxLength(150);
            address.Property(a => a.Neighborhood).HasColumnName("Neighborhood").HasMaxLength(100);
            address.Property(a => a.City).HasColumnName("City").HasMaxLength(100);
            address.Property(a => a.ZipCode).HasColumnName("ZipCode").HasMaxLength(20);
            address.Property(a => a.State).HasColumnName("State").HasMaxLength(50);
        });
    }
}
