using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configuration;

public class ContactopersonaConfiguration : IEntityTypeConfiguration<Contactopersona>
{
    public void Configure(EntityTypeBuilder<Contactopersona> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("contactopersona");

        builder.HasIndex(e => e.IdPers, "IdPers");

        builder.HasIndex(e => e.IdTcontacto, "IdTContacto");

        builder.Property(e => e.Descripcion).HasMaxLength(60);
        builder.Property(e => e.IdTcontacto).HasColumnName("IdTContacto");

        builder.HasOne(d => d.IdPersNavigation).WithMany(p => p.Contactopersonas)
            .HasForeignKey(d => d.IdPers)
            .HasConstraintName("contactopersona_ibfk_1");

        builder.HasOne(d => d.IdTcontactoNavigation).WithMany(p => p.Contactopersonas)
            .HasForeignKey(d => d.IdTcontacto)
            .HasConstraintName("contactopersona_ibfk_2");
    }
}