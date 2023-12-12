using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("persona");

        builder.HasIndex(e => e.IdCatego, "IdCatego");

        builder.HasIndex(e => e.IdCiudad, "IdCiudad");

        builder.HasIndex(e => e.IdPersona, "IdPersona").IsUnique();

        builder.HasIndex(e => e.IdTipoPer, "IdTipoPer");

        builder.Property(e => e.IdPersona).HasMaxLength(80);
        builder.Property(e => e.Nombre).HasMaxLength(100);

        builder.HasOne(d => d.IdCategoNavigation).WithMany(p => p.Personas)
            .HasForeignKey(d => d.IdCatego)
            .HasConstraintName("persona_ibfk_2");

        builder.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Personas)
            .HasForeignKey(d => d.IdCiudad)
            .HasConstraintName("persona_ibfk_3");

        builder.HasOne(d => d.IdTipoPerNavigation).WithMany(p => p.Personas)
            .HasForeignKey(d => d.IdTipoPer)
            .HasConstraintName("persona_ibfk_1");
    }
}