using Eleven.OralExpert.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eleven.OralExpert.Infra.Map;

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses"); // Nome da tabela no banco de dados

        builder.HasKey(a => a.Id); // Definição da chave primária

        builder.Property(a => a.Id)
            .IsRequired()
            .ValueGeneratedNever(); // O GUID será gerado no código

        builder.Property(a => a.Street)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(a => a.Neighborhood)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(a => a.City)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(a => a.ZipCode)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(a => a.State)
            .IsRequired()
            .HasMaxLength(100);
    }
}