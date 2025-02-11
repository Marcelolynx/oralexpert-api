using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Eleven.OralExpert.Domain.Entities;

namespace Eleven.OralExpert.Infra.Map;
public class EmployeeMap : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
         

        builder.Property(e => e.Position)
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