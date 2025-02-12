using Eleven.OralExpert.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eleven.OralExpert.Infra.Map;

public class SpecialtyMap
{
    public void Configure(EntityTypeBuilder<Specialty> builder)
    {
        builder.ToTable("Specialties"); // 🔥 Define o nome da tabela no banco

        builder.HasKey(s => s.Id); // 🔥 Define a chave primária

        builder.Property(s => s.Name) // 🔥 Nome da especialidade
            .IsRequired()
            .HasMaxLength(100);

        // 🔥 Caso queira adicionar especialidades fixas, pode usar um seed inicial
        builder.HasData(
            new Specialty(Guid.NewGuid(), "Cirurgia e Traumatologia Buco-Maxilo-Facial"),
            new Specialty(Guid.NewGuid(), "Dentística"),
            new Specialty(Guid.NewGuid(), "Disfunção Temporomandibular e Dor Orofacial"),
            new Specialty(Guid.NewGuid(), "Endodontia"),
            new Specialty(Guid.NewGuid(), "Radiologia Odontológica e Imaginologia"),
            new Specialty(Guid.NewGuid(), "Implantodontia"),
            new Specialty(Guid.NewGuid(), "Odontogeriatria"),
            new Specialty(Guid.NewGuid(), "Odontologia Legal"),
            new Specialty(Guid.NewGuid(), "Odontologia do Trabalho"),
            new Specialty(Guid.NewGuid(), "Odontologia para Pacientes com Necessidades Especiais"),
            new Specialty(Guid.NewGuid(), "Odontopediatria"),
            new Specialty(Guid.NewGuid(), "Ortodontia"),
            new Specialty(Guid.NewGuid(), "Ortopedia Funcional dos Maxilares")
        );
    }
}