using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Eleven.OralExpert.Domain.Entities; 

namespace Eleven.OralExpert.Infra.Map;
public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(u => u.Password)
            .IsRequired();

        builder.Property(u => u.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(u => u.IsActive) // 🔥 Adicionando ao mapeamento
            .HasDefaultValue(true) // Começa como `true`
            .IsRequired();

        builder.HasOne(u => u.Clinic)
            .WithMany()
            .HasForeignKey(u => u.ClinicId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasDiscriminator<string>("UserType")
            .HasValue<User>("User")
            .HasValue<Doctor>("Doctor")
            .HasValue<Employee>("Employee")
            .HasValue<Patient>("Patient");

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