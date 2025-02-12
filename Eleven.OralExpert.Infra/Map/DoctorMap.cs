using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Eleven.OralExpert.Domain.Entities;

namespace Eleven.OralExpert.Infra.Map;
public class DoctorMap : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.LastName) // 🔥 Adicionado LastName
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(d => d.Password)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(d => d.BoardCode) // 🔥 CRM, CRO, etc.
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(d => d.BoardNumber) // 🔥 Número do registro profissional
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(d => d.BoardState) // 🔥 Estado da licença
            .IsRequired()
            .HasMaxLength(2);

        builder.Property(d => d.SpecialtyId) // 🔥 Relacionamento com Especialidade
            .IsRequired();

        builder.HasOne(d => d.Clinic) // 🔥 Relacionamento com a Clínica
            .WithMany()
            .HasForeignKey(d => d.ClinicId)
            .OnDelete(DeleteBehavior.Restrict);
        
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