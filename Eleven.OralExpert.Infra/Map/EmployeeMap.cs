using Eleven.OralExpert.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eleven.OralExpert.Infra.Map;

public class EmployeeMap : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Position)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(e => e.User)
            .WithOne(u => u.Employer)
            .HasForeignKey<Employee>(e => e.UserId);
    }
}