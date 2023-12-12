using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configuration;

public class TipocontactoConfiguration : IEntityTypeConfiguration<Tipocontacto>
{
    public void Configure(EntityTypeBuilder<Tipocontacto> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("tipocontacto");

        builder.Property(e => e.Descripcion).HasMaxLength(100);
    }
}