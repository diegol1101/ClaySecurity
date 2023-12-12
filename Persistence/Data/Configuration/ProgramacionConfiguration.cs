using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configuration;

public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
{
    public void Configure(EntityTypeBuilder<Programacion> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("programacion");

        builder.HasIndex(e => e.IdContrato, "IdContrato");

        builder.HasIndex(e => e.IdEmpleado, "IdEmpleado");

        builder.HasIndex(e => e.IdTurno, "IdTurno");

        builder.HasOne(d => d.IdContratoNavigation).WithMany(p => p.Programacions)
            .HasForeignKey(d => d.IdContrato)
            .HasConstraintName("programacion_ibfk_1");

        builder.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Programacions)
            .HasForeignKey(d => d.IdEmpleado)
            .HasConstraintName("programacion_ibfk_3");

        builder.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.Programacions)
            .HasForeignKey(d => d.IdTurno)
            .HasConstraintName("programacion_ibfk_2");
    }
}