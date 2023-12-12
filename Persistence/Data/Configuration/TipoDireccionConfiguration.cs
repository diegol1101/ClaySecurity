using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configuration;

public class TipodireccionConfiguration : IEntityTypeConfiguration<Tipodireccion>
{
    public void Configure(EntityTypeBuilder<Tipodireccion> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("tipodireccion");

        builder.Property(e => e.Descripcion).HasMaxLength(100);
    }
}