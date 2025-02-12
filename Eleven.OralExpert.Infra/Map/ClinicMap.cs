using Eleven.OralExpert.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eleven.OralExpert.Infra.Map;

public class ClinicMap : IEntityTypeConfiguration<Clinic>
{
    public void Configure(EntityTypeBuilder<Clinic> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id) // 🔥 Explicitamente mapeia o Id
            .ValueGeneratedNever(); // 🔥 Importante para manter o ID fixo no HasData

        builder.Property(c => c.BrandName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.CorporateName)
            .IsRequired()
            .HasMaxLength(150);

        // 🔥 Configuração de Address como Owned Entity
        builder.OwnsOne(c => c.Address, address =>
        {
            address.Property(a => a.Street).HasColumnName("Street").HasMaxLength(150);
            address.Property(a => a.Neighborhood).HasColumnName("Neighborhood").HasMaxLength(100);
            address.Property(a => a.City).HasColumnName("City").HasMaxLength(100);
            address.Property(a => a.ZipCode).HasColumnName("ZipCode").HasMaxLength(20);
            address.Property(a => a.State).HasColumnName("State").HasMaxLength(50);
        });

        // 🔥 Inserindo um dado inicial na tabela `Clinic`
        builder.HasData(new
        {
            Id = Guid.Parse("f8c0b4f5-3c4f-4c28-bb22-5c1c8d2d36d1"), // 🔥 Agora explicitamente definido
            BrandName = "J. G. Paiva Oliveira - ME",
            CorporateName = "Paiva Instituto Oral & Maxilofacial",
            Address = new Address("Rua 25 de Dezembro, 929", "Jardim dos Estados", "Campo Grande", "MS", "79002-061")
        });
    }
}
