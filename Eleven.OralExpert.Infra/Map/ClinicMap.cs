using Eleven.OralExpert.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eleven.OralExpert.Infra.Map;

public class ClinicMap : IEntityTypeConfiguration<Clinic>
{
    public void Configure(EntityTypeBuilder<Clinic> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.TipoPessoa)
            .IsRequired();

        builder.Property(c => c.NomeMarca)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(c => c.RazaoSocial)
            .HasMaxLength(150);

        builder.Property(c => c.Endereco)
            .HasMaxLength(250);
        
        builder.Property(c => c.Telefone) 
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(c => c.Logomarca)
            .HasMaxLength(250); 

        builder.Property(c => c.Cnpj)
            .HasMaxLength(14)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.ResponsavelTecnico)
            .HasMaxLength(150); 
    }   
}