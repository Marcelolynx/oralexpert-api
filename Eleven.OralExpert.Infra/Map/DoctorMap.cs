using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Eleven.OralExpert.Domain.Entities;

namespace Eleven.OralExpert.Infra.Map
{
    public class DoctorMap : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.CRO)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(d => d.Especialidade)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(d => d.User)
                .WithOne(u => u.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId);
        }
    }
}
