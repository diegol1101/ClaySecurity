using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configuration;

public class DirpersonaConfiguration : IEntityTypeConfiguration<Dirpersona>
{
    public void Configure(EntityTypeBuilder<Dirpersona> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("dirpersona");

        builder.HasIndex(e => e.IdPerso, "IdPerso");

        builder.HasIndex(e => e.IdTdireccion, "IdTDireccion");

        builder.Property(e => e.Direccion).HasMaxLength(150);
        builder.Property(e => e.IdTdireccion).HasColumnName("IdTDireccion");

        builder.HasOne(d => d.IdPersoNavigation).WithMany(p => p.Dirpersonas)
            .HasForeignKey(d => d.IdPerso)
            .HasConstraintName("dirpersona_ibfk_1");

        builder.HasOne(d => d.IdTdireccionNavigation).WithMany(p => p.Dirpersonas)
            .HasForeignKey(d => d.IdTdireccion)
            .HasConstraintName("dirpersona_ibfk_2");
    }
}